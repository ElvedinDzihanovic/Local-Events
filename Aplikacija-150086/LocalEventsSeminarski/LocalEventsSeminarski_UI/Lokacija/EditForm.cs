using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_API.Models;
using LocalEventsSeminarski_UI.Util;
using MetroFramework.Forms;

namespace LocalEventsSeminarski_UI.Lokacija
{
    public partial class EditForm : MetroForm
    {
        private WebAPIHelper lokacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaRoute);
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);
        private WebAPIHelper lokacijaTipService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaTipRoute);


        private int lokacijaID;
        //private esp_Lokacija_GetByID_Result lokacija { get; set; }

        public EditForm(int selectedLokacijaID)
        {
            InitializeComponent();
            lokacijaID = selectedLokacijaID;

            // disabling the title bar
            //this.ControlBox = false;

            kapacitetInput.Maximum = 500000;
            this.Text = "Edit Location";

            this.AutoValidate = AutoValidate.Disable;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            HttpResponseMessage responseLokacija = lokacijaService.GetActionResponse("GetById", lokacijaID.ToString()); //lokacijaService.GetResponse(lokacijaID.ToString());


            if (responseLokacija.IsSuccessStatusCode) {
                esp_Lokacija_GetByID_Result lokacija = responseLokacija.Content.ReadAsAsync<esp_Lokacija_GetByID_Result>().Result;
                nazivInput.Text = lokacija.Naziv;
                opisInput.Text = lokacija.Opis;
                adresaInput.Text = lokacija.Adresa;
                gradSelect.Text = lokacija.GradNaziv;
                kapacitetInput.Value = Convert.ToDecimal(lokacija.Kapacitet);
                tipSelect.Text = lokacija.LokacijaTip;

                if (!lokacija.AverageRating.HasValue || lokacija.AverageRating.Value == 0)
                    averageRatingInput.Text = "Not Rated Yet";
                else
                    averageRatingInput.Text = lokacija.AverageRating.ToString();

                averageRatingInput.ReadOnly = true;

                if(lokacija.SlikaThumb != null)
                    pictureBox1.Image = UIHelper.ByteToImage(lokacija.SlikaThumb);


                HttpResponseMessage responseGrad = gradService.GetResponse();
                if (responseGrad.IsSuccessStatusCode) { 
                    List<Grad> gradovi = responseGrad.Content.ReadAsAsync<List<Grad>>().Result;
                    gradSelect.DataSource = gradovi;
                    gradSelect.ValueMember = "GradID";
                    gradSelect.DisplayMember = "Naziv";

                    gradSelect.Text = lokacija.GradNaziv; //...
                }

                HttpResponseMessage responseTipLokacije = lokacijaTipService.GetResponse();
                if (responseTipLokacije.IsSuccessStatusCode)
                {
                    List<LokacijaTip> tipovi = responseTipLokacije.Content.ReadAsAsync<List<LokacijaTip>>().Result;
                    tipSelect.DataSource = tipovi;
                    tipSelect.ValueMember = "LokacijaTipID";
                    tipSelect.DisplayMember = "Naziv";

                    //
                    tipSelect.Text = lokacija.LokacijaTip;
                }
            }
            else
            {
                MessageBox.Show("error loading lokacija");
            }
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) {

            LocalEventsSeminarski_API.Models.Lokacija lokacija = new LocalEventsSeminarski_API.Models.Lokacija();

            lokacija.LokacijaID = lokacijaID;
            lokacija.Naziv = nazivInput.Text;
            lokacija.Adresa = adresaInput.Text;
            lokacija.Kapacitet = Convert.ToInt32(kapacitetInput.Value);
            lokacija.Opis = opisInput.Text;
            lokacija.GradID = Convert.ToInt32(gradSelect.SelectedValue);
            lokacija.LokacijaTipID = Convert.ToInt32(tipSelect.SelectedValue);
            
            //MessageBox.Show(lokacijaID.ToString() + " " + lokacija.Naziv + " " + lokacija.Adresa + lokacija.Kapacitet.ToString());
            
            HttpResponseMessage saveChangesResponse = lokacijaService.PutResponse(lokacija.LokacijaID, lokacija);

            if (saveChangesResponse.IsSuccessStatusCode)
            {
                    MessageBox.Show("Saved Changes!");
                    Close();
            }
            else
            {
                MessageBox.Show("error");
            }
            
            }
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
            if (tipSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(tipSelect, Messages.field_req);
            }
        }

        private void kapacitetInput_Validating(object sender, CancelEventArgs e)
        {
            if (kapacitetInput.Value < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(kapacitetInput, Messages.kapacitet_err);
            }
            else if(kapacitetInput.Value > kapacitetInput.Maximum)
            {
                e.Cancel = true;
                errorProvider.SetError(kapacitetInput, Messages.kapacitet_err2);
            }
            else
                errorProvider.SetError(kapacitetInput, null);
        }

        private void adresaInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(adresaInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(adresaInput, Messages.field_req);
            }
            else
                errorProvider.SetError(adresaInput, null);
        }

        private void gradSelect_Validating(object sender, CancelEventArgs e)
        {
            if (gradSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(gradSelect, Messages.field_req);
            }
        }
    }
}
