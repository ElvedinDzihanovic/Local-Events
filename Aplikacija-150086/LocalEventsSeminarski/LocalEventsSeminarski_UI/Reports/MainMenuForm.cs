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
    public partial class MainMenuForm : Form
    {
        private WebAPIHelper gradService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.GradRoute);

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            BindGrad();
            BindMjesec();
        }

        private void BindMjesec()
        {
            List<string> mjeseci = new List<string>();
            mjeseci.Add("1");
            mjeseci.Add("2");
            mjeseci.Add("3");
            mjeseci.Add("4");
            mjeseci.Add("5");
            mjeseci.Add("6");
            mjeseci.Add("7");
            mjeseci.Add("8");
            mjeseci.Add("9");
            mjeseci.Add("10");
            mjeseci.Add("11");
            mjeseci.Add("12");
            
            mjesecSelect.DataSource = mjeseci;
            
        }

        private void BindGrad()
        {
            HttpResponseMessage response = gradService.GetResponse();

            if (response.IsSuccessStatusCode)
            {
                //MessageBox.Show("success: " + response.StatusCode.ToString());

                List<esp_Grad_SelectAll_Result> gradoviList = response.Content.ReadAsAsync<List<esp_Grad_SelectAll_Result>>().Result;
                List<esp_Grad_SelectAll_Result> gradoviList2 = new List<esp_Grad_SelectAll_Result>();

                foreach(var grad in gradoviList)
                {
                    gradoviList2.Add(new esp_Grad_SelectAll_Result
                    {
                        GradID = grad.GradID,
                        Naziv = grad.Naziv
                    });
                }

                gradSelect1.DataSource = gradoviList;
                gradSelect1.DisplayMember = "Naziv";
                gradSelect1.ValueMember = "GradID";


                gradSelect2.DataSource = gradoviList2;
                gradSelect2.DisplayMember = "Naziv";
                gradSelect2.ValueMember = "GradID";

            }
            else
                MessageBox.Show(response.StatusCode.ToString());
        }

        private void createReportBtn1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gradSelect1.SelectedValue.ToString());
            LokacijeReportViewForm reportFrm1 = new LokacijeReportViewForm(Convert.ToInt32(gradSelect1.SelectedValue));
            reportFrm1.Show();
        }

        private void createReportBtn2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(gradSelect2.SelectedValue.ToString() + " / " + mjesecSelect.SelectedValue.ToString());
            TopEventsReportViewForm reportFrm2 = new TopEventsReportViewForm(Convert.ToInt32(gradSelect2.SelectedValue), Convert.ToInt32(mjesecSelect.SelectedValue));
            reportFrm2.Show();
        }
        
    }
}
