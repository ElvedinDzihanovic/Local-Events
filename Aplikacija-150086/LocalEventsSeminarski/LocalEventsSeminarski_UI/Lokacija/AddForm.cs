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

namespace LocalEventsSeminarski_UI.Lokacija
{
    public partial class AddForm : MetroForm
    {
        private LocalEventsEntities2 db = new LocalEventsEntities2();
        private WebAPIHelper korisnikService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KorisnikRoute);
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);
        private WebAPIHelper lokacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaRoute);
        private WebAPIHelper lokacijaTipService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaTipRoute);

        private LocalEventsSeminarski_API.Models.Lokacija novaLokacija = new LocalEventsSeminarski_API.Models.Lokacija();

        public AddForm()
        {
            InitializeComponent();
            // disabling the title bar
            this.ControlBox = false;

            this.Text = "Add New Location";
            this.AutoValidate = AutoValidate.Disable;

            kapacitetInput.Maximum = 500000;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            BindGrad();
            BindLokacijaTip();
        }

        private void BindLokacijaTip()
        {
            HttpResponseMessage response = lokacijaTipService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                List<esp_LokacijaTip_SelectAll_Result> lokacijaTipList = response.Content.ReadAsAsync<List<esp_LokacijaTip_SelectAll_Result>>().Result;

                //lokacijaTipList.Insert(0, new LokacijaTip());
                lokacijaTipSelect.DataSource = lokacijaTipList;
                lokacijaTipSelect.DisplayMember = "Naziv";
                lokacijaTipSelect.ValueMember = "LokacijaTipID";
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void BindGrad()
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
                MessageBox.Show("error grad");
            }
        }

        private void slikaDodajBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            slikaInput.Text = openFileDialog1.FileName;

            novaLokacija.Slika = File.ReadAllBytes(slikaInput.Text);
            Image orgImage = Image.FromFile(slikaInput.Text);

            int resizedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgWidth"]);
            int resizedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resizedImgHeight"]);
            int croppedImgWidth = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgWidth"]);
            int croppedImgHeight = Convert.ToInt32(ConfigurationManager.AppSettings["croppedImgHeight"]);

            if (orgImage.Width > resizedImgWidth)
            {
                Image resizedImg = UIHelper.ResizeImage(orgImage, new Size(resizedImgWidth, resizedImgHeight));

                if (resizedImg.Width > croppedImgWidth && resizedImg.Height > croppedImgHeight)
                {
                    int croppedXPosition = (resizedImg.Width - croppedImgWidth) / 2;
                    int croppedYPosition = (resizedImg.Height - croppedImgHeight) / 2;

                    Image croppedImg = UIHelper.CropImage(resizedImg, new Rectangle(croppedXPosition, croppedYPosition, croppedImgWidth, croppedImgHeight));
                    lokacijaPictureBox.Image = croppedImg;


                    using (var ms = new MemoryStream()) { 
                        croppedImg.Save(ms, orgImage.RawFormat);

                    novaLokacija.SlikaThumb = ms.ToArray();
                    }
                }
                else
                {
                    MessageBox.Show("error");
                    novaLokacija = null;
                }
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {

                novaLokacija.Naziv = nazivInput.Text;

                novaLokacija.Opis = opisInput.Text;

                novaLokacija.Adresa = adresaInput.Text;
                novaLokacija.AverageRating = 0;


                novaLokacija.Kapacitet = Convert.ToInt32(kapacitetInput.Value);


                novaLokacija.GradID = Convert.ToInt32(gradSelect.SelectedValue);
                novaLokacija.LokacijaTipID = Convert.ToInt32(lokacijaTipSelect.SelectedValue);
                
                HttpResponseMessage response = lokacijaService.PostResponse(novaLokacija);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("New Location Added!");
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

        private void kapacitetInput_Validating(object sender, CancelEventArgs e)
        {
            if (kapacitetInput.Value < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(kapacitetInput, Messages.kapacitet_err);
            }
            else if (kapacitetInput.Value > kapacitetInput.Maximum)
            {
                e.Cancel = true;
                errorProvider.SetError(kapacitetInput, Messages.kapacitet_err2);
            }
            else
                errorProvider.SetError(kapacitetInput, null);
        }
        

        private void gradSelect_Validating(object sender, CancelEventArgs e)
        {
            if (gradSelect.SelectedIndex < 1) //0
            {
                e.Cancel = true;
                errorProvider.SetError(gradSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(gradSelect, null);
        }

        private void lokacijaTipSelect_Validating(object sender, CancelEventArgs e)
        {
            if (lokacijaTipSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(lokacijaTipSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(lokacijaTipSelect, null);
        }

        private void slikaInput_Validating(object sender, CancelEventArgs e)
        {
            if (lokacijaPictureBox == null || lokacijaPictureBox.Image == null)
            {
                e.Cancel = true;
                errorProvider.SetError(slikaInput, Messages.slika_error);
            }
            else
                errorProvider.SetError(slikaInput, null);
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
    }
}
