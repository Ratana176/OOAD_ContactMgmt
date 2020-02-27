using Project.Client.WinApp.Models;
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
    public partial class FrmAllPeople : Form
    {
        public FrmAllPeople()
        {
            InitializeComponent();
            InitData();

        }

        private void InitData()
        {
            var people = new PersonModel().All();
            dgvPeople.Columns.Clear();
            dgvPeople.DataSource = people;

            var btnView = new DataGridViewButtonColumn();
            var btnEdit = new DataGridViewButtonColumn();

            btnView.HeaderText = "View";
            btnView.Name = "btnView";
            btnView.UseColumnTextForButtonValue = true;
            btnView.Text = "view";


            btnEdit.HeaderText = "Edit";
            btnEdit.Name = "btnEdit";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Text = "edit";

            dgvPeople.Columns.AddRange(new DataGridViewColumn[] { btnView, btnEdit });
        }

        private void dgvPeople_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var button = senderGrid.Columns[e.ColumnIndex];
            if (!(button is DataGridViewButtonColumn) || e.RowIndex < 0) return;
            var id = (int)senderGrid["Id", e.RowIndex].Value;
            var title = ((DataGridViewButtonColumn)button).Text;

            if (title.Equals("edit")) Edit(id);
            else Display(id);
        }

        private void Edit(int id)
        {
            if(new FrmManagePerson(id).ShowForm() != -1)
            {
                InitData();
            }
        }

        private static void Display(int id)
        {
            new ViewProfile(id).ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearch.Text;

            dgvPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dgvPeople.Rows)
                {
                    row.Selected = false;
                    foreach (var item in row.Cells)
                    {
                        if (item is DataGridViewTextBoxCell)
                        {
                            var column = (DataGridViewTextBoxCell)item;
                            if (column.Value.ToString().Contains(searchValue))
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
