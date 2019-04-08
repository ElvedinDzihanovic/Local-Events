using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_API.Models;
using LocalEventsSeminarski_UI.Util;
using MetroFramework.Forms;
using System.Web.Http;

namespace LocalEventsSeminarski_UI.Organizacija
{
    public partial class AddForm : MetroForm
    {
        private WebAPIHelper organizacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.OrganizacijaRoute);
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);

        private LocalEventsSeminarski_API.Models.Organizacija novaOrganizacija = new LocalEventsSeminarski_API.Models.Organizacija();
        
        public AddForm()
        {
            InitializeComponent();
            // disabling the title bar
            //this.ControlBox = false;

            this.Text = "Add New Organization";

            this.AutoValidate = AutoValidate.Disable;
        }

        private async void AddForm_Load(object sender, EventArgs e)
        {
            BindTipSelect();
            await BindGradSelectAsync();
        }

        void BindTipSelect()
        {
            List<OrganizacijaTip> tipovi = new List<OrganizacijaTip>
            {
                new OrganizacijaTip("Obrazovna ustanova"),
                new OrganizacijaTip("Udruzenje gradjana"),
                new OrganizacijaTip("Just For Fun")
            };

            tipovi.Insert(0, new OrganizacijaTip());
            tipSelect.DataSource = tipovi;
            tipSelect.DisplayMember = "Text";
            tipSelect.ValueMember = "Text";
        }

        async Task BindGradSelectAsync()
        {
            HttpResponseMessage response = gradService.GetResponse();
            
            if (response.IsSuccessStatusCode)
            {
                //MessageBox.Show("success: " + response.StatusCode.ToString());
                
                List<esp_Grad_SelectAll_Result> gradoviList = response.Content.ReadAsAsync<List<esp_Grad_SelectAll_Result>>().Result;
                

                gradSelect.DataSource = gradoviList;
                gradSelect.DisplayMember = "Naziv";
                gradSelect.ValueMember = "GradID";
            }
            else
            {
                string text = await response.Content.ReadAsStringAsync();

                MessageBox.Show(text);

            }
            
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            novaOrganizacija.Naziv = nazivInput.Text;
            novaOrganizacija.Opis = opisInput.Text;
            novaOrganizacija.Tip = tipSelect.SelectedValue.ToString();
            novaOrganizacija.GradID = Convert.ToInt32(gradSelect.SelectedValue);
            novaOrganizacija.AverageRating = 0;
                
            HttpResponseMessage response = organizacijaService.PostResponse(novaOrganizacija);

            if (response.IsSuccessStatusCode)
            {
                    MessageBox.Show("New Organization Added!");
                    this.Close();
            }
            else
            {
                    string msg = response.ReasonPhrase;
                    
                    MessageBox.Show("Error Code" +
                    response.StatusCode + " : Message - " + msg);
            }
            }
        }

        private void slikaDodajBtn_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            slikaInput.Text = openFileDialog1.FileName;

            novaOrganizacija.SlikaLogo = File.ReadAllBytes(slikaInput.Text);

            Image orgImage = Image.FromFile(slikaInput.Text);
            organizacijaPictureBox.Image = orgImage;
        }
        private void nazivInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nazivInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(nazivInput, Messages.field_req);
            }
            else if (nazivInput.Text.Length < 2)
            {
                e.Cancel = true;
                errorProvider.SetError(nazivInput, Messages.naziv_length_error);
            }
            else
                errorProvider.SetError(nazivInput, null);
        }

        private void opisInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(opisInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(opisInput, Messages.field_req);
            }
            else if (opisInput.Text.Length < 20)
            {
                e.Cancel = true;
                errorProvider.SetError(opisInput, Messages.opis_length_err);
            }
            else
                errorProvider.SetError(opisInput, null);
        }

        private void tipSelect_Validating(object sender, CancelEventArgs e)
        {
            if (tipSelect.SelectedIndex < 1) //0?
            {
                e.Cancel = true;
                errorProvider.SetError(tipSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(tipSelect, null);
        }

        private void gradSelect_Validating(object sender, CancelEventArgs e)
        {
            if (gradSelect.SelectedIndex < 0) //0?
            {
                e.Cancel = true;
                errorProvider.SetError(gradSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(gradSelect, null);
        }

        private void slikaInput_Validating(object sender, CancelEventArgs e)
        {
            if (organizacijaPictureBox == null || organizacijaPictureBox.Image == null)
            {
                e.Cancel = true;
                errorProvider.SetError(slikaInput, Messages.slika_error);
            }
            else
                errorProvider.SetError(slikaInput, null);
        }
    }
}
