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

namespace LocalEventsSeminarski_UI.Reports
{
    public partial class TopEventsReportViewForm : Form
    {
        private WebAPIHelper eventService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.EventRoute);
        private int gradID { get; set; }
        private int mjesec { get; set; }

        public TopEventsReportViewForm(int selectedGrad, int selectedMjesec)
        {
            InitializeComponent();
            gradID = selectedGrad;
            mjesec = selectedMjesec;
        }

        private void TopEventsReportViewForm_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = eventService.GetTwoParameterResponse("GetTopFive", gradID.ToString(), mjesec.ToString());

            if (response.IsSuccessStatusCode)
            {
                List<esp_Event_Top5ByGradMjesec_Result> events = response.Content
                    .ReadAsAsync<List<esp_Event_Top5ByGradMjesec_Result>>().Result;
                //ReportDataSource rds = new ReportDataSource("lokacije", lokacije);

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("EventsDataSet", events));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GradID", gradID.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Mjesec", mjesec.ToString()));      
            }
            else
                MessageBox.Show(response.StatusCode.ToString());

            this.reportViewer1.RefreshReport();
        }
    }
}
