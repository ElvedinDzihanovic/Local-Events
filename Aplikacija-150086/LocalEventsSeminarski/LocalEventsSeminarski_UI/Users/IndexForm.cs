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

namespace LocalEventsSeminarski_UI.Users
{
    public partial class IndexForm : MetroFramework.Forms.MetroForm
    {
        private WebAPIHelper korisnikService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KorisnikRoute);

        public IndexForm()
        {
            InitializeComponent();
            usersGrid.AutoGenerateColumns = false;
            
            //disabling the title bar
            this.ControlBox = false;
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            HttpResponseMessage response = korisnikService.GetActionResponse("SearchByName", imePrezimeInput.Text.Trim());

            if (response.IsSuccessStatusCode)
            {
                List<esp_Korisnik_SelectAll_Result> korisnici = response.Content.ReadAsAsync<List<esp_Korisnik_SelectAll_Result>>().Result;
                usersGrid.DataSource = korisnici;
                usersGrid.ClearSelection();
            }
            else
            {
                MessageBox.Show("Error");
            }
            
        }

        private void pretraziBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            //filter by status (aktivan, neaktivan...)
        }

        private void izmijeniKorisnikaBtn_Click(object sender, EventArgs e)
        {
            var red = usersGrid.SelectedCells[0].RowIndex;

            var odabraniKorisnikID = usersGrid.Rows[red].Cells[0].Value;

            EditForm editFrm = new EditForm(Convert.ToInt32(odabraniKorisnikID));
            editFrm.ShowDialog();
        }
        
    }
}
