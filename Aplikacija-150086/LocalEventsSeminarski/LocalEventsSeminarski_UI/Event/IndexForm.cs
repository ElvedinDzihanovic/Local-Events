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
    public partial class IndexForm : MetroForm
    {
        private WebAPIHelper eventService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventRoute);

        public IndexForm()
        {
            InitializeComponent();
            eventDataGridView.AutoGenerateColumns = false;
            // disabling the title bar
            this.ControlBox = false;

            this.Text = "Event Index";

        }
        
        private void IndexForm_Load(object sender, EventArgs e)
        {
            BindEvents();
            
        }

        private void BindEvents()
        {
            HttpResponseMessage eventResponse = eventService.GetActionResponse("GetByNaziv", nazivInput.Text.Trim());

            if (eventResponse.IsSuccessStatusCode)
            {
                List<esp_Event_GetEvents_Result> events = eventResponse.Content.ReadAsAsync<List<esp_Event_GetEvents_Result>>().Result;

                foreach(var item in events)
                {
                    item.DatumOdrzavanja = item.DatumOdrzavanja.Date;
                }

                eventDataGridView.DataSource = events;

            }
            else
            {
                MessageBox.Show("event error");
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            //filter by status (odrzan, neodrzan event)
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(eventDataGridView.SelectedCells.Count > 0) { 
            var red = eventDataGridView.SelectedCells[0].RowIndex;

            int odabraniEventID = Convert.ToInt32(eventDataGridView.Rows[red].Cells[0].Value);

            EditForm editFrm = new EditForm(odabraniEventID);

            editFrm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BindEvents();
        }
    }
}
