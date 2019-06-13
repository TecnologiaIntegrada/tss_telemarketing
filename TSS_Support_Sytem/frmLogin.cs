using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSS_Support_Sytem.Model;
using TSS_Support_Sytem.Utils;
using TSS_Support_Sytem.Views;

namespace TSS_Support_Sytem
{
    public partial class frmLogin : Form
    {
        public AppSettings appSettings { get; set; }

        public frmLogin(AppSettings appSettings)
        {
            InitializeComponent();
            this.appSettings = appSettings;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtName.Text;
            String password = txtPassword.Text;

            try
            {
                User user = Login.DoLogin(username, password, this.appSettings);

                if (user != null)
                {
                    FormMain main = new FormMain(user, appSettings);
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Invalid user or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
