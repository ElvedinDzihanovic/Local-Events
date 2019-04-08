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
using Microsoft.Reporting.WebForms;

namespace LocalEventsSeminarski_UI.Reports
{
    public partial class LokacijeReportViewForm : Form
    {
        private int gradID { get; set; }
        private WebAPIHelper lokacijaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.LokacijaRoute);

        public LokacijeReportViewForm(int grad)
        {
            InitializeComponent();
            gradID = grad;
        }

        private void LokacijeReportViewForm_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = lokacijaService.GetActionResponse("GetTopFive", gradID.ToString());

            if (response.IsSuccessStatusCode)
            {
                List<esp_Lokacija_GetTop5ByGrad_Result> lokacije = response.Content.ReadAsAsync<List<esp_Lokacija_GetTop5ByGrad_Result>>().Result;
                //ReportDataSource rds = new ReportDataSource("lokacije", lokacije);

                this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Lokacije", lokacije));

                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("GradID", gradID.ToString()));


            }
            else
                MessageBox.Show(response.StatusCode.ToString());

            this.reportViewer1.RefreshReport();
        }
    }
}
