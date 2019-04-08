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
    public partial class AddSlikaForm : MetroForm
    {
        private WebAPIHelper slikaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.SlikaRoute);
        private int eventGalleryID { get; set; }
        private Slika novaSlika = new Slika();

        public AddSlikaForm(int _eventGalleryID)
        {
            InitializeComponent();
            eventGalleryID = _eventGalleryID;
            // disabling the title bar
            //this.ControlBox = false;

            this.Text = "New Image Form";

            this.AutoValidate = AutoValidate.Disable;
        }
        

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            novaSlika.EventGalleryID = eventGalleryID;
            novaSlika.Opis = opisInput.Text;
            
            //rijesiti dodavanje slike...

            HttpResponseMessage slikaResponse = slikaService.PostResponse(novaSlika);

            if (slikaResponse.IsSuccessStatusCode)
            {
                Close();
            }
            else
            {
                MessageBox.Show("slika post error");
            }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            slikaInput.Text = openFileDialog1.FileName;

            novaSlika.Slika1 = File.ReadAllBytes(slikaInput.Text);
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
                    slikaPictureBox.Image = croppedImg;

                    MemoryStream ms = new MemoryStream();
                    croppedImg.Save(ms, orgImage.RawFormat);

                    novaSlika.SlikaThumb = ms.ToArray();
                }
                else
                {
                    MessageBox.Show("error");
                    novaSlika = null;
                }
            }
        }

        private void slikaInput_Validating(object sender, CancelEventArgs e)
        {
            if (slikaPictureBox == null || slikaPictureBox.Image == null)
            {
                e.Cancel = true;
                errorProvider.SetError(slikaInput, Messages.slika_error);
            }
            else
                errorProvider.SetError(slikaInput, null);
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
    }
}
