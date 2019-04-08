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

namespace LocalEventsSeminarski_UI.Organizacija
{
    public partial class EditForm : MetroForm
    {
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);
        private WebAPIHelper organizacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.OrganizacijaRoute);

        private int organizacijaID;
        //private LocalEventsSeminarski_API.Models.Organizacija Organizacija { get; set; }

        public EditForm(int selectedOrganizacijaID)
        {
            InitializeComponent();
            organizacijaID = selectedOrganizacijaID;
            // disabling the title bar
            //this.ControlBox = false;

            this.Text = "Edit Organization";

            this.AutoValidate = AutoValidate.Disable;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = organizacijaService.GetActionResponse("GetById", organizacijaID.ToString());

            if (response.IsSuccessStatusCode)
            {
                esp_Organizacija_GetByID_Result Organizacija = response.Content.ReadAsAsync<esp_Organizacija_GetByID_Result>().Result;

                nameInput.Text = Organizacija.Naziv;
                opisInput.Text = Organizacija.Opis;

                if (Organizacija.SlikaLogo != null)
                    pictureBox1.Image = UIHelper.ByteToImage(Organizacija.SlikaLogo);
                
                HttpResponseMessage gradResponse = gradService.GetResponse();

                if (gradResponse.IsSuccessStatusCode)
                {
                    List<Grad> gradovi = gradResponse.Content.ReadAsAsync<List<Grad>>().Result;

                    gradSelect.DataSource = gradovi;

                    gradSelect.DisplayMember = "Naziv";
                    gradSelect.ValueMember = "GradID";

                    gradSelect.Text = Organizacija.GradNaziv;

                    //gradSelect.SelectedValue = Organizacija.GradID;

                }
                else
                {
                    MessageBox.Show("error grad");
                }

                List<OrganizacijaTip> tipovi = new List<OrganizacijaTip>
                {
                    new OrganizacijaTip("Obrazovna ustanova"),
                    new OrganizacijaTip("Udruzenje gradjana"),
                    new OrganizacijaTip("Just For Fun")
                };

                tipSelect.DataSource = tipovi;
                tipSelect.DisplayMember = "Text";
                tipSelect.ValueMember = "Text";

                tipSelect.SelectedValue = Organizacija.Tip;
                tipSelect.Text = Organizacija.Tip;
            }
            else
            {
                MessageBox.Show("error loading organizacija");
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren()) { 
            LocalEventsSeminarski_API.Models.Organizacija editedOrganizacija = new LocalEventsSeminarski_API.Models.Organizacija();

            editedOrganizacija.OrganizacijaID = organizacijaID;
            editedOrganizacija.Naziv = nameInput.Text;
            editedOrganizacija.Opis = opisInput.Text;
            editedOrganizacija.GradID = Convert.ToInt32(gradSelect.SelectedValue);
            editedOrganizacija.Tip = tipSelect.SelectedValue.ToString();
            editedOrganizacija.SlikaLogo = null;
               
            HttpResponseMessage putResponse = organizacijaService.PutResponse(organizacijaID, editedOrganizacija);

            if (putResponse.IsSuccessStatusCode)
            {
                    MessageBox.Show("Saved Changes!");
                    this.Close();
            }
            else
            {
                MessageBox.Show("error put response");
            }
            }
        }

        private void nameInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(nameInput.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(nameInput, Messages.field_req);
            }
            else if (nameInput.Text.Length < 2)
            {
                e.Cancel = true;
                errorProvider.SetError(nameInput, Messages.naziv_length_error);
            }
            else
                errorProvider.SetError(nameInput, null);
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
