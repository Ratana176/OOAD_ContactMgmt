using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Client.WinApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            var form = new FrmAllPeople();
            form.ShowDialog();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var form = new FrmManagePerson();
            form.ShowDialog();
        }
    }
}
