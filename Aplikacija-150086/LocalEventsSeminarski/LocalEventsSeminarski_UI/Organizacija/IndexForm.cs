using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_UI.Util;
using LocalEventsSeminarski_API.Models;
using System.Net.Http;
using MetroFramework.Forms;

namespace LocalEventsSeminarski_UI.Organizacija
{
    public partial class IndexForm : MetroForm
    {
        private WebAPIHelper organizacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.OrganizacijaRoute);

        public IndexForm()
        {
            InitializeComponent();
            organizacijaDataGrid.AutoGenerateColumns = false;
            // disabling the title bar
            this.ControlBox = false;

        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            OrganizacijaDataGridBind();
        }

        private void OrganizacijaDataGridBind()
        {
            HttpResponseMessage response = organizacijaService.GetActionResponse("SearchByName",nazivInput.Text.Trim());

            if (response.IsSuccessStatusCode)
            {
                List<LocalEventsSeminarski_API.Models.Organizacija> organizacije = response.Content.ReadAsAsync<List<LocalEventsSeminarski_API.Models.Organizacija>>().Result;

                organizacijaDataGrid.DataSource = organizacije;
            }
            else
            {
                MessageBox.Show("Organizacija Binding Error: " + response.StatusCode.ToString());
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var red = organizacijaDataGrid.SelectedCells[0].RowIndex;

            var odabranaOrganizacijaID = organizacijaDataGrid.Rows[red].Cells[0].Value;

            EditForm editFrm = new EditForm(Convert.ToInt32(odabranaOrganizacijaID));
            editFrm.ShowDialog();
        }

        private void pretraziBtn_Click(object sender, EventArgs e)
        {
            OrganizacijaDataGridBind();
        }
    }
}
