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

namespace TSS_Support_Sytem.Views
{
    public partial class FormUsers : Form
    {
        private AppSettings appSettings;

        public FormUsers(AppSettings appSettings)
        {
            InitializeComponent();
            dataGridView1.DataSource = new NodeSQL(appSettings).GetData("SELECT * FROM users").ToDataTable();
        }
    }
}
