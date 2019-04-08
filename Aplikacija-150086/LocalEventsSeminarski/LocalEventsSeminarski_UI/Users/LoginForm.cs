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

namespace LocalEventsSeminarski_UI.Users
{
    public partial class LoginForm : MetroForm //bilo je samo LoginForm: Form
    {
        private WebAPIHelper korisnikService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.KorisnikRoute);
        private WebAPIHelper ulogaService = new WebAPIHelper(ConfigurationManager.AppSettings["APIAddress"], Global.UlogaRoute);

        public LoginForm()
        {
            InitializeComponent();

            this.Text = "Login @ Local Events";
            this.AutoValidate = AutoValidate.Disable;

            
        }


        private void loginButton_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren()) { 
            HttpResponseMessage korisnikResponse = korisnikService.GetActionResponse("GetByUsername", usernameInput.Text);


            
            if (korisnikResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            { 
                MessageBox.Show(Messages.login_username_err, Messages.error, 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            else  if (korisnikResponse.IsSuccessStatusCode)
            {
                Korisnik k = korisnikResponse.Content.ReadAsAsync<Korisnik>().Result;

                if (UIHelper.GenerateHash(passwordInput.Text, k.LozinkaSalt) == k.LozinkaHash)
                {
                    HttpResponseMessage ulogaResponse = ulogaService.GetActionResponse("IsAdmin", k.KorisnikID.ToString());
                        if (ulogaResponse.IsSuccessStatusCode) {
                            bool isAdmin = ulogaResponse.Content.ReadAsAsync<bool>().Result;

                            if (isAdmin)
                            {

                                this.DialogResult = DialogResult.OK;
                                Global.prijavljeniKorisnik = k;
                                //MessageBox.Show("success!");
                                this.Close();
                            }
                            else
                                MessageBox.Show("You do not have the permission to access desktop app!");

                        }
                    }
                else
                {
                    MessageBox.Show(Messages.login_pass_err, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("server error");
                //MessageBox.Show(Messages.login_username_err, Messages.error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }

        private void usernameInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(usernameInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(usernameInput, Messages.field_req);
            }
            else if (usernameInput.Text.Contains(".")) //UKLONITI KASNIJE...
            {
                e.Cancel = true;
                errorProvider1.SetError(usernameInput, "Tacka!");
            }
            else
            {
                errorProvider1.SetError(usernameInput, null);
            }
        }

        private void passwordInput_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(passwordInput.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(passwordInput, Messages.field_req);
            }
            else
                errorProvider1.SetError(passwordInput, null);
        }
    }
}
