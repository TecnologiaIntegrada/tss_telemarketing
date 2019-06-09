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

namespace TSS_Support_Sytem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String base_url = "http://127.0.0.1:3000";
            String username = txtName.Text;
            String password = txtPassword.Text;
            Login login = Login.DoLogin(username, password, base_url);

        }
    }
}
