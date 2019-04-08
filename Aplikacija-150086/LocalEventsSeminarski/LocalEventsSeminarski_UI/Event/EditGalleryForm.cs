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
using LocalEventsSeminarski_UI.Util;
using LocalEventsSeminarski_API.Models;
using MetroFramework.Forms;

namespace LocalEventsSeminarski_UI.Event
{
    public partial class EditGalleryForm : MetroForm
    {
        private WebAPIHelper eventGalleryService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventGalleryRoute);
        private WebAPIHelper slikaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.SlikaRoute);

        private int galleryID { get; set; }
        private esp_EventGallery_GetByID_Result trazeniEvent { get; set; }

        public EditGalleryForm(int eventGalleryID)
        {
            InitializeComponent();
            slikeDataGrid.AutoGenerateColumns = false;
            slikeDataGrid.RowTemplate.Height = 75;

            galleryID = eventGalleryID;
            // disabling the title bar
            //this.ControlBox = false;
            this.Text = "Edit Gallery";
        }

        private void EditGalleryForm_Load(object sender, EventArgs e)
        {
            BindTextBoxes();
            BindGrid();

            this.AutoValidate = AutoValidate.Disable;

        }

        private void BindGrid()
        {
            HttpResponseMessage slikaResponse = slikaService.GetActionResponse("GetByGalleryID", galleryID.ToString());

            slikeDataGrid.DataSource = slikaResponse.Content.ReadAsAsync<List<esp_Slika_GetByGallery_Result>>().Result;
        }

        private void BindTextBoxes()
        {
            HttpResponseMessage eventGalleryResponse = eventGalleryService.GetResponse(galleryID.ToString());

            if (eventGalleryResponse.IsSuccessStatusCode)
            {
               trazeniEvent = eventGalleryResponse.Content.ReadAsAsync<esp_EventGallery_GetByID_Result>().Result;

                nazivInput.Text = trazeniEvent.Naziv;
                opisInput.Text = trazeniEvent.Opis;


            }
            else
            {
                MessageBox.Show("error loading gallery");
            }
        }

        private void slikaDodajBtn_Click(object sender, EventArgs e)
        {
            AddSlikaForm addSlikaFrm = new AddSlikaForm(galleryID);
            addSlikaFrm.Show();
        }

       

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                LocalEventsSeminarski_API.Models.EventGallery editedGallery = new EventGallery();

                editedGallery.EventGalleryID = galleryID;
                editedGallery.Naziv = nazivInput.Text;
                editedGallery.Opis = opisInput.Text;
                editedGallery.DatumKreiranja = trazeniEvent.DatumKreiranja;
                editedGallery.EventID = trazeniEvent.EventID;
                


                int id = galleryID;

                HttpResponseMessage putResponse = eventGalleryService.PutResponse(id, editedGallery);

                if (putResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Saved Changes!");
                }
                else
                    MessageBox.Show(putResponse.StatusCode.ToString());
                
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(slikeDataGrid.SelectedCells.Count > 0) { 
            var red = slikeDataGrid.SelectedCells[0].RowIndex;

            var odabranaSlika = slikeDataGrid.Rows[red].Cells[0].Value;

            Event.EditImageForm editSlikaFrm = new EditImageForm(Convert.ToInt32(odabranaSlika));
            editSlikaFrm.Show();
            }
        }

        private void refreshGridBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
