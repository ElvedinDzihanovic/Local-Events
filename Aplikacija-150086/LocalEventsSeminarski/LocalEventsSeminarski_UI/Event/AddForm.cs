using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_API.Models;
using LocalEventsSeminarski_UI.Util;
using MetroFramework.Forms;

namespace LocalEventsSeminarski_UI.Event
{
    public partial class AddForm : MetroForm
    {
        private WebAPIHelper eventTipService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventTipRoute);
        private WebAPIHelper eventService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventRoute);
        private WebAPIHelper lokacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaRoute);
        private WebAPIHelper organizacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.OrganizacijaRoute);
        private WebAPIHelper ageRangeService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.AgeRangeRoute);
        private LocalEventsSeminarski_API.Models.Event noviEvent = new LocalEventsSeminarski_API.Models.Event();

        public AddForm()
        {
            InitializeComponent();
            // disabling the title bar
            this.ControlBox = false;

            this.Text = "Add New Event";
            this.AutoValidate = AutoValidate.Disable;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            vrijemePocetkaSelect.Format = DateTimePickerFormat.Time;
            vrijemePocetkaSelect.CustomFormat = "HH:mm";
            vrijemePocetkaSelect.ShowUpDown = true;

            vrijemeKrajaSelect.Format = DateTimePickerFormat.Time;
            vrijemeKrajaSelect.CustomFormat = "HH:mm";
            vrijemeKrajaSelect.ShowUpDown = true;

            //try { 
            BindEventTip();
            BindAgeRange();
            BindOrganizacija();
            BindLokacija();
            //}
            //catch(Exception ex)
            //{
                
            //}
        }

        private void BindAgeRange()
        {
            HttpResponseMessage ageRangeResponse = ageRangeService.GetResponse();

            if (ageRangeResponse.IsSuccessStatusCode)
            {
                List<esp_AgeRange_SelectAll_Result> ageRanges = ageRangeResponse.Content.ReadAsAsync<List<esp_AgeRange_SelectAll_Result>>().Result;

                ageRangeCheck.DataSource = ageRanges;
                ageRangeCheck.DisplayMember = "Range";
                ageRangeCheck.ValueMember = "AgeRangeID";
                ageRangeCheck.ClearSelected();
            }
            else
            {
                MessageBox.Show("age range error");
            }
        }

        private void BindLokacija()
        {
            HttpResponseMessage lokacijaResponse = lokacijaService.GetActionResponse("SelectAll");

            if (lokacijaResponse.IsSuccessStatusCode)
            {
                List<esp_Lokacija_SelectAll_Result> lokacije = lokacijaResponse.Content.ReadAsAsync<List<esp_Lokacija_SelectAll_Result>>().Result;
                lokacije.Insert(0, new esp_Lokacija_SelectAll_Result());
                lokacijaSelect.DataSource = lokacije;
                lokacijaSelect.ValueMember = "LokacijaID";
                lokacijaSelect.DisplayMember = "Naziv";
            }
            else
            {
                MessageBox.Show("lokacija load error");
            }
        }

        private void BindOrganizacija()
        {
            HttpResponseMessage organizacijaResponse = organizacijaService.GetResponse();

            if (organizacijaResponse.IsSuccessStatusCode)
            {
                List<esp_Organizacija_SelectAll_Result> organizacije = organizacijaResponse.Content.ReadAsAsync<List<esp_Organizacija_SelectAll_Result>>().Result;

                //organizacije.Insert(0, new LocalEventsSeminarski_API.Models.Organizacija());

                organizacijaSelect.DataSource = organizacije;
                organizacijaSelect.DisplayMember = "Naziv";
                organizacijaSelect.ValueMember = "OrganizacijaID";
            }
            else
            {
                MessageBox.Show("error organizacija loading");
            }
        }

        private void BindEventTip()
        {
            HttpResponseMessage eventTipResponse = eventTipService.GetResponse();

            if (eventTipResponse.IsSuccessStatusCode)
            {
                List<esp_EventTip_SelectAll_Result> eventTipList = eventTipResponse.Content.ReadAsAsync<List<esp_EventTip_SelectAll_Result>>().Result;

                //eventTipList.Insert(0, new EventTip());

                eventTipSelect.DataSource = eventTipList;
                eventTipSelect.DisplayMember = "Naziv";
                eventTipSelect.ValueMember = "EventTipID";
                
            }
            else
            {
                MessageBox.Show("event tip error");
            }
        }


        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            noviEvent.Naziv = nazivInput.Text;
            noviEvent.Opis = opisInput.Text;
            noviEvent.DatumKreiranja = DateTime.Now;
            noviEvent.DatumOdrzavanja = datumOdrzavanjaSelect.Value;

            TimeSpan vrijemePocetkaTimeSpan = DateTime.Parse(vrijemePocetkaSelect.Value.ToShortTimeString()).TimeOfDay;
            noviEvent.VrijemePocetka = vrijemePocetkaTimeSpan;

            TimeSpan vrijemeZavrsetkaTimeSpan = DateTime.Parse(vrijemeKrajaSelect.Value.ToShortTimeString()).TimeOfDay;
            noviEvent.VrijemeZavrsetka = vrijemeZavrsetkaTimeSpan;

            noviEvent.EventTipID = Convert.ToInt32(eventTipSelect.SelectedValue);

            noviEvent.OrganizacijaID = Convert.ToInt32(organizacijaSelect.SelectedValue);

            noviEvent.KreatorID = Global.prijavljeniKorisnik.KorisnikID;
            //noviEvent.KreatorID = Global.prijavljeniKorisnik.KorisnikID;


            //noviEvent.Slika = null;
            //noviEvent.SlikaThumb = null;

            noviEvent.AverageRating = 0;

            //kasnije, u editu dodati change status
            noviEvent.Status = "Neodrzan";

            //rijesiti ovo za lokaciju...

            
            noviEvent.LokacijaID = Convert.ToInt32(lokacijaSelect.SelectedValue);

            var items = ageRangeCheck.CheckedItems.Cast<esp_AgeRange_SelectAll_Result>().ToList();

            foreach(var item in items)
            {
                noviEvent.AgeRanges.Add(new AgeRange
                {
                    AgeRangeID = item.AgeRangeID,
                    Range = item.Range
                });
            }
            


            HttpResponseMessage eventResponse = eventService.PostResponse(noviEvent);
            //HttpResponseMessage eventResponse = eventService.GetResponse();

            if (eventResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("New Event Added!");
                this.Close();
            }
                else {
                    //MessageBox.Show(eventResponse.Headers.ToString() + " " + eventResponse.ReasonPhrase.ToString());
                    string msg = eventResponse.ReasonPhrase;

                    //if (!String.IsNullOrEmpty(Messages.ResourceManager.GetString(eventResponse.ReasonPhrase)))
                    //    msg = Messages.ResourceManager.GetString(eventResponse.ReasonPhrase);

                    MessageBox.Show("Error Code" +
                    eventResponse.StatusCode + " : Message - " + msg);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.ShowDialog();
            slikaInput.Text = openFileDialog1.FileName;

            noviEvent.Slika = File.ReadAllBytes(slikaInput.Text);
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
                    eventPictureBox.Image = croppedImg;

                    using(var ms = new MemoryStream()) { 
                        croppedImg.Save(ms, orgImage.RawFormat);
                        noviEvent.SlikaThumb = ms.ToArray();
                    }
                }
                else
                {
                    MessageBox.Show("error");
                    noviEvent = null;
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

        private void datumOdrzavanjaSelect_Validating(object sender, CancelEventArgs e)
        {
            int result = DateTime.Compare(datumOdrzavanjaSelect.Value, DateTime.Now);

            if (result < 0) //mozda doraditi ovo...
            {
                e.Cancel = true;
                errorProvider.SetError(datumOdrzavanjaSelect, "Event Date Error!");
            }
            else
                errorProvider.SetError(datumOdrzavanjaSelect, null);

        }

        private void vrijemePocetkaSelect_Validating(object sender, CancelEventArgs e)
        {
            int result = DateTime.Compare(vrijemePocetkaSelect.Value, vrijemeKrajaSelect.Value);

            if (result >= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(vrijemePocetkaSelect, "Error");
            }
            else
                errorProvider.SetError(vrijemePocetkaSelect, null);
        }

        private void vrijemeKrajaSelect_Validating(object sender, CancelEventArgs e)
        {
            int result = DateTime.Compare(vrijemePocetkaSelect.Value, vrijemeKrajaSelect.Value);

            if (result >= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(vrijemeKrajaSelect, "Error");
            }
            else
                errorProvider.SetError(vrijemeKrajaSelect, null);
        }

        private void eventTipSelect_Validating(object sender, CancelEventArgs e)
        {
            if (eventTipSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(eventTipSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(eventTipSelect, null);
        }

        private void ageRangeCheck_Validating(object sender, CancelEventArgs e)
        {
            if (ageRangeCheck.SelectedItems.Count < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(ageRangeCheck, Messages.ageRange_check_err);
            }
            else
                errorProvider.SetError(ageRangeCheck, null);
        }

        private void lokacijaSelect_Validating(object sender, CancelEventArgs e)
        {
            if (lokacijaSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(lokacijaSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(lokacijaSelect, null);
        }

        private void slikaInput_Validating(object sender, CancelEventArgs e)
        {
            if (eventPictureBox == null || eventPictureBox.Image == null)
            {
                e.Cancel = true;
                errorProvider.SetError(slikaInput, Messages.slika_error);
            }
            else
                errorProvider.SetError(slikaInput, null);
        }

        private void organizacijaSelect_Validating(object sender, CancelEventArgs e)
        {
            if (organizacijaSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(organizacijaSelect, Messages.field_req);
            }
            else
                errorProvider.SetError(organizacijaSelect, null);
        }
    }
}
