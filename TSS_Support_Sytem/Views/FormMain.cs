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

namespace TSS_Support_Sytem.Views
{
    public partial class FormMain : Form
    {
        public AppSettings appSettings;

        public FormMain(User user, AppSettings appSettings)
        {
            InitializeComponent();
            this.Text = String.Format("Telemarketing Support System - {0}", user.email);
            this.appSettings = appSettings;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void rbUsers_Click(object sender, EventArgs e)
        {
            FormUsers users = new FormUsers(this.appSettings);
            users.ShowDialog();
        }
    }
}
