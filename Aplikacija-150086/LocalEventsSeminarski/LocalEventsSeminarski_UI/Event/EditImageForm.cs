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

namespace LocalEventsSeminarski_UI.Event
{
    public partial class EditImageForm : Form
    {
        private WebAPIHelper slikaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.SlikaRoute);
        private int SlikaID { get; set; }
        private GetSlikaByID_Result slikaResult { get; set; }

        public EditImageForm(int selectedSlikaID)
        {
            InitializeComponent();

            SlikaID = selectedSlikaID;

            this.AutoValidate = AutoValidate.Disable;
        }

        private void EditImageForm_Load(object sender, EventArgs e)
        {
            BindSlika();
        }

        private void BindSlika()
        {
            HttpResponseMessage slikaResponse = slikaService.GetActionResponse("GetSlikaByID", SlikaID.ToString());

            if (slikaResponse.IsSuccessStatusCode)
            {
                slikaResult = slikaResponse.Content.ReadAsAsync<GetSlikaByID_Result>().Result;

                imageDescription.Text = slikaResult.Opis;
                imagePictureBox.Image = UIHelper.ByteToImage(slikaResult.SlikaThumb);
            }
            else
                MessageBox.Show("error");
        }

        private void imageDescription_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(imageDescription.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(imageDescription, Messages.field_req);
            }
            else if (imageDescription.Text.Length < 20)
            {
                e.Cancel = true;
                errorProvider.SetError(imageDescription, Messages.opis_length_err);
            }
            else
                errorProvider.SetError(imageDescription, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                //put response...
                Slika editedSlika = new Slika();
                editedSlika.SlikaID = SlikaID;
                editedSlika.Slika1 = slikaResult.Slika;
                editedSlika.SlikaThumb = slikaResult.SlikaThumb;
                editedSlika.Opis = imageDescription.Text;

                HttpResponseMessage putResponse = slikaService.PutResponse(SlikaID, editedSlika);

                if (putResponse.IsSuccessStatusCode)
                {
                    MessageBox.Show("Saved Changes!");
                    this.Close();
                }
                else
                    MessageBox.Show(putResponse.StatusCode.ToString());
            }
        }
    }
}
