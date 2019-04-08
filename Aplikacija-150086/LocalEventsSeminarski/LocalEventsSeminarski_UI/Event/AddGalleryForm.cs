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

namespace LocalEventsSeminarski_UI.Event
{
    public partial class AddGalleryForm : MetroForm
    {
        private WebAPIHelper eventGalleryService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventGalleryRoute);

        private int galleryEventID { get; set; }

        public AddGalleryForm(int eventID)
        {
            InitializeComponent();
            galleryEventID = eventID;
            // disabling the title bar
            //this.ControlBox = false;

            this.Text = "New Gallery Form";

            this.AutoValidate = AutoValidate.Disable;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            EventGallery eventGallery = new EventGallery();
            eventGallery.EventID = galleryEventID;
            eventGallery.DatumKreiranja = DateTime.Now;
            eventGallery.Naziv = nazivInput.Text;
            eventGallery.Opis = opisRichTextBox.Text;

            HttpResponseMessage galleryResponse = eventGalleryService.PostResponse(eventGallery);

            if (galleryResponse.IsSuccessStatusCode)
            {
                MessageBox.Show("New Gallery Added!");
                this.Close();
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

        private void opisRichTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(opisRichTextBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(opisRichTextBox, Messages.field_req);
            }
            else if (opisRichTextBox.Text.Length < 20)
            {
                e.Cancel = true;
                errorProvider.SetError(opisRichTextBox, Messages.opis_length_err);
            }
            else
                errorProvider.SetError(opisRichTextBox, null);
        }
    }
}
