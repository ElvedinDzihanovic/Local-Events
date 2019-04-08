using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LocalEventsSeminarski_UI.Users;

namespace LocalEventsSeminarski_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           
            LoginForm loginFrm = new LoginForm();
            loginFrm.ShowDialog();

            if(loginFrm.DialogResult == DialogResult.OK)
            Application.Run(new MainForm());

            //Application.Run(new MainForm());
            //Application.Run(new LoginForm());

        }
    }
}
