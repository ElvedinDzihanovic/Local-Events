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
    public partial class IndexForm : MetroForm
    {
        private WebAPIHelper lokacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaRoute);

        public int odabranaLokacijaID { get; set; }

        public IndexForm()
        {
            InitializeComponent();

            lokacijaDataGrid.AutoGenerateColumns = false;
            // disabling the title bar
            this.ControlBox = false;

            this.Text = "Locations Index";
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            BindLokacijaDataGrid();
            lokacijaDataGrid.AutoGenerateColumns = false;
        }

        private void BindLokacijaDataGrid()
        {
            HttpResponseMessage response = lokacijaService.GetActionResponse("SelectAll", nazivInput.Text.Trim());
            //HttpResponseMessage response = lokacijaService.GetActionResponse("SearchByName", "nekoIme");

            if (response.IsSuccessStatusCode)
            {
                List<esp_Lokacija_SelectAll_Result> lokacije = response.Content.ReadAsAsync<List<esp_Lokacija_SelectAll_Result>>().Result;
                lokacijaDataGrid.DataSource = lokacije;
            }
            else
            {
              MessageBox.Show(response.StatusCode.ToString());
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            lokacijaDataGrid.Update();
            lokacijaDataGrid.Refresh();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //dohvati red
            var cellIndex = lokacijaDataGrid.SelectedCells[0].RowIndex;
            //dohvati vrijednost prve celije tj. ID lokacije
            var cellCollection = lokacijaDataGrid.Rows[cellIndex].Cells[0].Value;

            odabranaLokacijaID = Convert.ToInt32(cellCollection);

            var editForm = new EditForm(odabranaLokacijaID);
            editForm.ShowDialog();
            
        }

        private void pretraziBtn_Click(object sender, EventArgs e)
        {
            BindLokacijaDataGrid();
        }
    }
}
