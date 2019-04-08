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

namespace LocalEventsSeminarski_UI.Reports
{
    public partial class EventReportViewForm : Form
    {
        private WebAPIHelper eventService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventRoute);
        private int eventID { get; set; }

        public EventReportViewForm(int selectedEventID)
        {
            InitializeComponent();
            eventID = selectedEventID;
        }

        private void EventReportViewForm_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = eventService.GetActionResponse("GetReport", eventID.ToString());

            if (response.IsSuccessStatusCode)
            {
                List<esp_Event_GetReport_Result> result = response.Content.ReadAsAsync<List<esp_Event_GetReport_Result>>().Result;
                
                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("SelectedEvent", result));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("EventID", eventID.ToString()));

            }
            else
                MessageBox.Show("There was a problem loading data.");

            this.reportViewer1.RefreshReport();
        }
    }
}
