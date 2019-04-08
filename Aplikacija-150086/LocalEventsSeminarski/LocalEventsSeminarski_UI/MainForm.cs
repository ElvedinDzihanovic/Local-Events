using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace LocalEventsSeminarski_UI
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*
            usersBtn.UseCustomBackColor = true;
            eventsBtn.UseCustomBackColor = true;
            locationsBtn.UseCustomBackColor = true;
            organizationsBtn.UseCustomBackColor = true;

            

            usersBtn.BackColor = MetroFramework.MetroColors.Red;
            eventsBtn.BackColor = MetroFramework.MetroColors.Green;
            locationsBtn.BackColor = MetroFramework.MetroColors.Yellow;
            organizationsBtn.BackColor = MetroFramework.MetroColors.Purple;
            */
        }

        
        private void locationsBtn_Click(object sender, EventArgs e)
        {
            Lokacija.IndexForm locationFrm = new Lokacija.IndexForm();
            locationFrm.Show();
        }

        private void organizationsBtn_Click(object sender, EventArgs e)
        {
            Organizacija.IndexForm organizationFrm = new Organizacija.IndexForm();
            organizationFrm.Show();
        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildren();
            Users.IndexForm usersFrm = new Users.IndexForm();
            usersFrm.MdiParent = this;
            usersFrm.Show();
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Users.AddForm addForm = new Users.AddForm();
            addForm.MdiParent = this;
            addForm.StartPosition = FormStartPosition.CenterScreen;

            addForm.Show();
        }

        private void CloseChildren()
        {
            foreach(var child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void indexToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Event.IndexForm eventsFrm = new Event.IndexForm();
            eventsFrm.MdiParent = this;
            eventsFrm.StartPosition = FormStartPosition.CenterScreen;
            eventsFrm.Show();
        }

        private void indexToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Lokacija.IndexForm lokacijaFrm = new Lokacija.IndexForm();
            lokacijaFrm.MdiParent = this;
            lokacijaFrm.StartPosition = FormStartPosition.CenterScreen;
            lokacijaFrm.Show();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Lokacija.AddForm lokacijaAddFrm = new Lokacija.AddForm();
            lokacijaAddFrm.MdiParent = this;
            lokacijaAddFrm.StartPosition = FormStartPosition.CenterScreen;
            lokacijaAddFrm.Show();
        }

        private void addNewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Event.AddForm eventAddFrm = new Event.AddForm();
            eventAddFrm.MdiParent = this;
            eventAddFrm.StartPosition = FormStartPosition.CenterScreen;
            eventAddFrm.Show();
        }

        private void indexToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Organizacija.IndexForm organizacijaIndexFrm = new Organizacija.IndexForm();
            organizacijaIndexFrm.MdiParent = this;
            organizacijaIndexFrm.StartPosition = FormStartPosition.CenterScreen;
            organizacijaIndexFrm.Show();
        }

        private void addNewToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CloseChildren();

            Organizacija.AddForm organizacijaAddFrm = new Organizacija.AddForm();
            organizacijaAddFrm.MdiParent = this;
            organizacijaAddFrm.StartPosition = FormStartPosition.CenterScreen;
            organizacijaAddFrm.Show();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.MainMenuForm reportsFrm = new Reports.MainMenuForm();
            reportsFrm.MdiParent = this;
            reportsFrm.StartPosition = FormStartPosition.CenterScreen;
            reportsFrm.Show();
        }
    }
}
