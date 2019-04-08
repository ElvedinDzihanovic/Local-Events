using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_API.Models;
using LocalEventsSeminarski_UI.Util;

namespace LocalEventsSeminarski_UI.Users
{
    public partial class EditForm : Form
    {
        private WebAPIHelper korisnikService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KorisnikRoute);
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);

        private esp_Korisnik_GetByUsername_Result korisnik { get; set; }
        private string username { get; set; }
        private int korisnikID { get; set; }

        public EditForm(int odabraniKorisnikID)
        {
            InitializeComponent();

            korisnikID = odabraniKorisnikID;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            BindGradovi();
            BindKorisnik();
        }

        private void BindGradovi()
        {
            HttpResponseMessage response = gradService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<esp_Grad_SelectAll_Result> gradoviList = response.Content.ReadAsAsync<List<esp_Grad_SelectAll_Result>>().Result;

                gradInput.DataSource = gradoviList;
                gradInput.DisplayMember = "Naziv";
                gradInput.ValueMember = "GradID";
            }
            else
            {
                MessageBox.Show("error grad");
            }
        }
        
        private void BindKorisnik()
        {
            HttpResponseMessage korisnikResponse = korisnikService.GetActionResponse("GetByID", korisnikID.ToString());

            if (korisnikResponse.IsSuccessStatusCode)
            {
                korisnik = korisnikResponse.Content.ReadAsAsync<esp_Korisnik_GetByUsername_Result>().Result;

                korisnikID = korisnik.KorisnikID;
                imeInput.Text = korisnik.Ime;
                prezimeInput.Text = korisnik.Prezime;
                emailInput.Text = korisnik.Email;
                usernameInput.Text = korisnik.KorisnickoIme;
                telefonInput.Text = korisnik.Telefon;

                List<string> statusList = new List<string>();
                statusList.Add("Active");
                statusList.Add("Not Active");

                statusSelect.DataSource = statusList;

                if (korisnik.Status == true)
                    statusSelect.Text = "Active";
                else
                    statusSelect.Text = "Not Active";

                telefonInput.Text = korisnik.Telefon;
                
                if(korisnik.SlikaThumb != null)
                    pictureBox1.Image = UIHelper.ByteToImage(korisnik.SlikaThumb);
            }
            else
                MessageBox.Show("error");
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            Korisnik editedKorisnik = new Korisnik();

            editedKorisnik.KorisnikID = korisnikID;
            editedKorisnik.Ime = imeInput.Text;
            editedKorisnik.Prezime = prezimeInput.Text;
            editedKorisnik.Email = emailInput.Text;
            editedKorisnik.Telefon = telefonInput.Text;
            editedKorisnik.GradID = Convert.ToInt32(gradInput.SelectedValue);
            editedKorisnik.KorisnickoIme = usernameInput.Text;

            editedKorisnik.Slika = editedKorisnik.Slika;
            editedKorisnik.SlikaThumb = editedKorisnik.SlikaThumb;

           
            

            if (statusSelect.Text == "Active")
                editedKorisnik.Status = true;
            else
                editedKorisnik.Status = false;


            
            if (String.IsNullOrEmpty(passwordInput.Text))
            {
                //MessageBox.Show("Don't change password!");
                editedKorisnik.LozinkaHash = korisnik.LozinkaHash;
                editedKorisnik.LozinkaSalt = korisnik.LozinkaSalt;
            }
            else { 
                //MessageBox.Show("Change password!");
                editedKorisnik.LozinkaSalt = UIHelper.GenerateSalt();
                editedKorisnik.LozinkaHash = UIHelper.GenerateHash(passwordInput.Text, editedKorisnik.LozinkaSalt);
            }

            try
            {
                HttpResponseMessage putResponse = korisnikService.PutResponse(editedKorisnik.KorisnikID, editedKorisnik);

                if (putResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Saved Changes!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void imeInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(imeInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(imeInput, Messages.field_req);
            }
            else
            {
                errorProvider.SetError(imeInput, null);
            }
        }

        private void prezimeInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(prezimeInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(prezimeInput, Messages.field_req);
            }
            else
            {
                errorProvider.SetError(prezimeInput, null);
            }
        }

        private void emailInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(emailInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(emailInput, Messages.field_req);
            }
            else
            {
                try
                {
                    MailAddress mail = new MailAddress(emailInput.Text);
                    errorProvider.SetError(emailInput, null);
                }
                catch (FormatException)
                {
                    e.Cancel = true;
                    errorProvider.SetError(emailInput, Messages.field_format_err);
                }
            }
        }

        private void usernameInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(usernameInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(usernameInput, Messages.field_req);
            }
            else if (usernameInput.Text.Length < 5)
            {
                e.Cancel = true;
                errorProvider.SetError(usernameInput, Messages.username_register_error);
            }
            else if (!Regex.IsMatch(usernameInput.Text, @"^[a-zA-Z0-9_]+$"))
            {
                e.Cancel = true;
                errorProvider.SetError(usernameInput, Messages.username_register_error2);
            }

            else
                errorProvider.SetError(usernameInput, null);
        }

        

        private void telefonInput_Validating(object sender, CancelEventArgs e)
        {
            if (telefonInput.Text.Any(char.IsLetter)) //mozda nije potrebno
            {
                e.Cancel = true;
                errorProvider.SetError(telefonInput, Messages.field_format_err);
            }
            else
                errorProvider.SetError(telefonInput, null);
        }

        private void passwordInput_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(passwordInput.Text))
            {
                if (passwordInput.Text.Length < 8)
                {
                    e.Cancel = true;
                    errorProvider.SetError(passwordInput, Messages.password_register_error);
                }
                else if (!passwordInput.Text.Any(char.IsDigit) || !passwordInput.Text.Any(char.IsLetter))
                {
                    e.Cancel = true;
                    errorProvider.SetError(passwordInput, Messages.password_register_error2);
                }
                else
                {
                    errorProvider.SetError(passwordInput, null);
                }
            }
        }

        private void gradInput_Validating(object sender, CancelEventArgs e)
        {
            if (gradInput.SelectedIndex < 1) //<0
            {
                e.Cancel = true;
                errorProvider.SetError(gradInput, Messages.field_req);
            }
            else
                errorProvider.SetError(gradInput, null);
        }
    }
}
