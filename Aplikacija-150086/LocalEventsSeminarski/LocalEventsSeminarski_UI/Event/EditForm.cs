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

namespace LocalEventsSeminarski_UI.Event
{
    public partial class EditForm : MetroForm
    {
        private WebAPIHelper eventTipService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventTipRoute);
        private WebAPIHelper eventService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventRoute);
        private WebAPIHelper lokacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaRoute);
        private WebAPIHelper organizacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.OrganizacijaRoute);
        private WebAPIHelper galleryService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventGalleryRoute);

        private int eventID { get; set; }
        private esp_Event_GetByID_Result editedEvent { get; set; }

        public EditForm(int selectedEventID) //dodati parametar selectedEventID
        {
            InitializeComponent();
            eventID = selectedEventID;
            // disabling the title bar
            //this.ControlBox = false;

            this.Text = "Edit Event";
            galleriesDataGrid.AutoGenerateColumns = false;

            this.AutoValidate = AutoValidate.Disable;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            
            vrijemePocetkaInput.Format = DateTimePickerFormat.Time;
            vrijemePocetkaInput.CustomFormat = "HH:mm";
            vrijemePocetkaInput.ShowUpDown = true;
            
            vrijemeKrajaInput.Format = DateTimePickerFormat.Time;
            vrijemeKrajaInput.CustomFormat = "HH:mm";
            vrijemeKrajaInput.ShowUpDown = true;
            /*
             TimeSpan vrijemePocetkaTimeSpan = DateTime.Parse(vrijemePocetkaSelect.Value.ToShortTimeString()).TimeOfDay;
            noviEvent.VrijemePocetka = vrijemePocetkaTimeSpan;
             */
            //vratiti se ovome kasnije malo...

            //ovdje bi moglo biti problema, pripaziti...
            HttpResponseMessage eventResponse = eventService.GetResponse(eventID.ToString());

            if (eventResponse.IsSuccessStatusCode)
            {
                editedEvent = eventResponse.Content.ReadAsAsync<esp_Event_GetByID_Result>().Result;

                nazivInput.Text = editedEvent.Naziv;
                opisInput.Text = editedEvent.Opis;
                datumOdrzavanjaInput.Value = editedEvent.DatumOdrzavanja;
                datumOdrzavanjaInput.Text = editedEvent.DatumOdrzavanja.ToString(); //mozda nije potrebno

                vrijemePocetkaInput.Text = editedEvent.VrijemePocetka.Value.ToString();
                vrijemePocetkaInput.Value = Convert.ToDateTime(vrijemePocetkaInput.Text);

                vrijemeKrajaInput.Text = editedEvent.VrijemeZavrsetka.Value.ToString();
                vrijemeKrajaInput.Value = Convert.ToDateTime(vrijemeKrajaInput.Text);
                
                ratingInput.ReadOnly = true;

                if (editedEvent.AverageRating == 0)
                    ratingInput.Text = "Not Rated Yet";
                else
                    ratingInput.Text = editedEvent.AverageRating.ToString();
                
                //bind lokacija
                HttpResponseMessage lokacijaResponse = lokacijaService.GetResponse();
                
                List<esp_Lokacija_SelectAll_Result> lokacije = lokacijaResponse.Content.ReadAsAsync<List<esp_Lokacija_SelectAll_Result>>().Result;

                lokacijaSelect.DataSource = lokacije;
                lokacijaSelect.ValueMember = "LokacijaID";
                lokacijaSelect.DisplayMember = "Naziv";

                //lokacijaSelect.Text = editedEvent.Lokacija.Naziv;
                lokacijaSelect.SelectedValue = editedEvent.LokacijaID;

                if (editedEvent.SlikaThumb != null)
                    eventImage.Image = UIHelper.ByteToImage(editedEvent.SlikaThumb);
                
                //bind event tip
                HttpResponseMessage eventTypeResponse = eventTipService.GetResponse();

                List<esp_EventTip_SelectAll_Result> eventTypeList = eventTypeResponse.Content.ReadAsAsync<List<esp_EventTip_SelectAll_Result>>().Result;

                eventTypeSelect.DataSource = eventTypeList;
                eventTypeSelect.ValueMember = "EventTipID";
                eventTypeSelect.DisplayMember = "Naziv";

                eventTypeSelect.SelectedValue = editedEvent.EventTipID;
                //eventTypeSelect.Text = editedEvent.EventTip.Naziv;

                //organizacija
                HttpResponseMessage organizacijaResponse = organizacijaService.GetResponse();

                List<esp_Organizacija_SelectAll_Result> organizacije = organizacijaResponse.Content.ReadAsAsync<List<esp_Organizacija_SelectAll_Result>>().Result;

                organizacijaSelect.DataSource = organizacije;
                organizacijaSelect.ValueMember = "OrganizacijaID";
                organizacijaSelect.DisplayMember = "Naziv";
                organizacijaSelect.SelectedValue = editedEvent.OrganizacijaID;
                //organizacijaSelect.Text = editedEvent.Organizacija.Naziv;

                //status
                statusSelect.Items.Add("Odrzan");
                statusSelect.Items.Add("Neodrzan");

                statusSelect.SelectedItem = editedEvent.Status;
            }
            else
                MessageBox.Show("event error");
            

            BindGalleryDataGrid();
        }

        private void BindGalleryDataGrid()
        {
            HttpResponseMessage galleryResponse = galleryService.GetActionResponse("GetByEvent", eventID.ToString());

            if (galleryResponse.IsSuccessStatusCode)
            {
                List<esp_EventGallery_GetByEvent_Result> galleryList = galleryResponse.Content.ReadAsAsync<List<esp_EventGallery_GetByEvent_Result>>().Result;
                galleriesDataGrid.DataSource = galleryList;
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            LocalEventsSeminarski_API.Models.Event putEvent = new LocalEventsSeminarski_API.Models.Event();

            putEvent.EventID = eventID;
            putEvent.Naziv = nazivInput.Text;
            putEvent.Opis = opisInput.Text;
            putEvent.LokacijaID = Convert.ToInt32(lokacijaSelect.SelectedValue);
            putEvent.OrganizacijaID = Convert.ToInt32(organizacijaSelect.SelectedValue);
            putEvent.EventTipID = Convert.ToInt32(eventTypeSelect.SelectedValue);
            putEvent.Status = statusSelect.SelectedItem.ToString();

                //putEvent.DatumKreiranja = DateTime.Now; 

                putEvent.DatumOdrzavanja = datumOdrzavanjaInput.Value;

            putEvent.VrijemePocetka = DateTime.Parse(vrijemePocetkaInput.Value.ToShortTimeString()).TimeOfDay;
            putEvent.VrijemeZavrsetka = DateTime.Parse(vrijemeKrajaInput.Value.ToShortTimeString()).TimeOfDay;

            HttpResponseMessage eventPutResponse = eventService.PutResponse(putEvent.EventID, putEvent);

            if (eventPutResponse.IsSuccessStatusCode)
            {
                    MessageBox.Show("Saved Changes!");
                    Close();
            }
            else
            {
                    MessageBox.Show("event put error");
            }
            }
        }

       

        private void newGalleryBtn_Click(object sender, EventArgs e)
        {
            Event.AddGalleryForm addGalleryFrm = new Event.AddGalleryForm(eventID);
            addGalleryFrm.Show();
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

        private void vrijemePocetkaInput_Validating(object sender, CancelEventArgs e)
        {
            int result = DateTime.Compare(vrijemePocetkaInput.Value, vrijemeKrajaInput.Value);

            if (result >= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(vrijemePocetkaInput, "Error");
            }
            else
                errorProvider.SetError(vrijemePocetkaInput, null);
        }

        private void vrijemeKrajaInput_Validating(object sender, CancelEventArgs e)
        {
            int result = DateTime.Compare(vrijemePocetkaInput.Value, vrijemeKrajaInput.Value);

            if (result >= 0)
            {
                e.Cancel = true;
                errorProvider.SetError(vrijemeKrajaInput, "Error");
            }
            else
                errorProvider.SetError(vrijemeKrajaInput, null);
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

        private void eventTypeSelect_Validating(object sender, CancelEventArgs e)
        {
            if (eventTypeSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(eventTypeSelect, Messages.field_req);
            }
        }

        private void organizacijaSelect_Validating(object sender, CancelEventArgs e)
        {
            if (organizacijaSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(organizacijaSelect, Messages.field_req);
            }
        }

        private void statusSelect_Validating(object sender, CancelEventArgs e)
        {
            if (statusSelect.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider.SetError(statusSelect, Messages.field_req);
            }
        }

        private void editGalleryBtn_Click(object sender, EventArgs e)
        {
            if(galleriesDataGrid.SelectedCells.Count > 0) { 
            var red = galleriesDataGrid.SelectedCells[0].RowIndex;

            var odabranaGalerija = galleriesDataGrid.Rows[red].Cells[0].Value;


            Event.EditGalleryForm editGalleryFrm = new Event.EditGalleryForm(Convert.ToInt32(odabranaGalerija));
            editGalleryFrm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindGalleryDataGrid();
        }

        private void reportBtn_Click(object sender, EventArgs e)
        {
            Reports.EventReportViewForm eventReportFrm = new Reports.EventReportViewForm(eventID);
            eventReportFrm.Show();
        }
    }
}
