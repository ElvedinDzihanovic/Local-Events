using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_API.Models;
using LocalEventsSeminarski_UI.Util;
using MetroFramework.Forms;

namespace LocalEventsSeminarski_UI.Users
{
    public partial class AddForm : MetroForm //Form
    {
        private WebAPIHelper korisnikService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KorisnikRoute);
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);
        private WebAPIHelper ulogaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.UlogaRoute);
        private WebAPIHelper posjetilacService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.PosjetilacRoute);

        private Korisnik noviKorisnik = new Korisnik();
        
        public AddForm()
        {
            InitializeComponent();
            // disabling the title bar
            this.ControlBox = false;

            this.AutoValidate = AutoValidate.Disable;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            BindGradovi();
            BindUloge();
        }

        private void BindUloge()
        {
            HttpResponseMessage ulogaResponse = ulogaService.GetResponse();

            if (ulogaResponse.IsSuccessStatusCode)
            {
                List<esp_Uloga_SelectAll_Result> uloge = ulogaResponse.Content.ReadAsAsync<List<esp_Uloga_SelectAll_Result>>().Result;
                ulogeListBox.DataSource = uloge;
                ulogeListBox.DisplayMember = "Naziv";
                ulogeListBox.ValueMember = "UlogaID";
                ulogeListBox.ClearSelected();
            }
        }

        private void BindGradovi()
        {
            HttpResponseMessage response = gradService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<esp_Grad_SelectAll_Result> gradoviList = response.Content.ReadAsAsync<List<esp_Grad_SelectAll_Result>>().Result;

                gradSelect.DataSource = gradoviList;
                gradSelect.DisplayMember = "Naziv";
                gradSelect.ValueMember = "GradID";
            }
            else
            {
                MessageBox.Show("Grad Binding Error: " + response.StatusCode.ToString());
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gradSelect.SelectedValue.ToString() + " / " + gradSelect.SelectedIndex.ToString());

            if (this.ValidateChildren()) { 
            noviKorisnik.Ime = imeInput.Text;
            noviKorisnik.Prezime = prezimeInput.Text;
            noviKorisnik.Email = emailInput.Text;
            noviKorisnik.KorisnickoIme = korisnickoImeInput.Text;
            
            noviKorisnik.LozinkaSalt = UIHelper.GenerateSalt();
            noviKorisnik.LozinkaHash = UIHelper.GenerateHash(passwordInput.Text, noviKorisnik.LozinkaSalt);

            noviKorisnik.Telefon = telefonInput.Text;

            noviKorisnik.GradID = Convert.ToInt32(gradSelect.SelectedValue);
            noviKorisnik.Status = true;

            var items = ulogeListBox.CheckedItems.Cast<esp_Uloga_SelectAll_Result>().ToList();

            foreach (var item in items)
            {
                    noviKorisnik.KorisnikUlogas.Add(new KorisnikUloga
                    {
                        KorisnikID = noviKorisnik.KorisnikID,
                        UlogaID = item.UlogaID,
                        DatumIzmjene = DateTime.Now
                    });
            }

            HttpResponseMessage response = korisnikService.PostResponse(noviKorisnik);

            if (response.IsSuccessStatusCode)
            {
                    int idKorisnika = response.Content.ReadAsAsync<int>().Result;

                    Posjetilac noviPosjetilac = new Posjetilac
                    {
                        PosjetilacID = idKorisnika,
                        BrojPosjecenihDogadjaja = 0,
                        Zanimanje = zanimanjeInput.Text
                    };

                    try { 
                        posjetilacService.PostResponse(noviPosjetilac);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Creating Posjetilac Error: " + ex.Message);
                    }

                    MessageBox.Show("New User Added!");

                    this.Close();
            }
                else
                {
                    string msg = response.ReasonPhrase;

                    if (!String.IsNullOrEmpty(Messages.ResourceManager.GetString(response.ReasonPhrase)))
                        msg = Messages.ResourceManager.GetString(response.ReasonPhrase);

                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + msg);
                }
            }
        }

        private void slikaDodajBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            slikaInput.Text = openFileDialog1.FileName;

            noviKorisnik.Slika = File.ReadAllBytes(slikaInput.Text);
            Image orgImage = Image.FromFile(slikaInput.Text);

            int resizedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgWidth"]);
            int resizedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgHeight"]);
            int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
            int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

            if(orgImage.Width > resizedImgWidth)
            {
                Image resizedImg = UIHelper.ResizeImage(orgImage, new Size(resizedImgWidth, resizedImgHeight));

                if(resizedImg.Width > croppedImgWidth && resizedImg.Height > croppedImgHeight)
                {
                    int croppedXPosition = (resizedImg.Width - croppedImgWidth) / 2;
                    int croppedYPosition = (resizedImg.Height - croppedImgHeight) / 2;

                    Image croppedImg = UIHelper.CropImage(resizedImg, new Rectangle(croppedXPosition, croppedYPosition, croppedImgWidth, croppedImgHeight));
                    userPictureBox.Image = croppedImg;

                    using (var ms = new MemoryStream())
                    {
                        croppedImg.Save(ms, orgImage.RawFormat);
                           noviKorisnik.SlikaThumb = ms.ToArray();
                    }
                }
                else
                {
                    MessageBox.Show(Messages.picture_war + " " + resizedImgWidth + "x" + resizedImgHeight + ".", Messages.warning,
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    noviKorisnik = null;
                }
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
                catch(FormatException)
                {
                    e.Cancel = true;
                    errorProvider.SetError(emailInput, Messages.field_format_err);
                }
            }
        }

        private void korisnickoImeInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(korisnickoImeInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, Messages.field_req);
            }
            else if (korisnickoImeInput.Text.Length < 5)
            {
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, Messages.username_register_error);
            }
            else if(!Regex.IsMatch(korisnickoImeInput.Text, @"^[a-zA-Z0-9_]+$")){
                e.Cancel = true;
                errorProvider.SetError(korisnickoImeInput, Messages.username_register_error2);
            }

            else
                errorProvider.SetError(korisnickoImeInput, null);
        }
        

        private void passwordInput_Validating(object sender, CancelEventArgs e)
        {
            
            if (String.IsNullOrEmpty(passwordInput.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider.SetError(passwordInput, Messages.field_req);
            }
            else
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

        private void gradSelect_Validating(object sender, CancelEventArgs e)
        {
            if (gradSelect.SelectedIndex < 0) //<0
            {
                e.Cancel = true;
                errorProvider.SetError(gradSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(gradSelect, null);
        }

        private void telefonInput_Validating_1(object sender, CancelEventArgs e)
        {
            
            if (telefonInput.Text.Any(char.IsLetter)) //mozda nije potrebno
            {
                e.Cancel = true;
                errorProvider.SetError(telefonInput, Messages.field_format_err);
            }
            else
                errorProvider.SetError(telefonInput, null);

        }

        private void slikaInput_Validating(object sender, CancelEventArgs e)
        {
            if (userPictureBox == null || userPictureBox.Image == null)
            {
                e.Cancel = true;
                errorProvider.SetError(slikaInput, Messages.slika_error);
            }
            else
                errorProvider.SetError(slikaInput, null);
        }

        private void ulogeListBox_Validating(object sender, CancelEventArgs e)
        {
            if (ulogeListBox.SelectedItems.Count < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(ulogeListBox, "You must select one!");
            }
            else
                errorProvider.SetError(ulogeListBox, null);
        }

        private void zanimanjeInput_Validating(object sender, CancelEventArgs e)
        {
            //DORADITI
            var roles = ulogeListBox.SelectedItems.Cast<esp_Uloga_SelectAll_Result>().ToList();

            if(roles.Any(r=>r.Naziv == "Posjetilac"))
            {
                if (String.IsNullOrEmpty(zanimanjeInput.Text))
                {
                    e.Cancel = true;
                    errorProvider.SetError(zanimanjeInput, "This field is required for visitor!");
                }
                else
                    errorProvider.SetError(zanimanjeInput, null);
            }
        }


        //Napisati proceduru za dodavanje korisnika

    }
}
