using Project.Client.WinApp.Domain.Entities;
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
    public partial class FrmManagePerson : Form
    {
        private PersonBuilder personBuilder;
        private PersonModel PersonModel;
        public FrmManagePerson(int id = -1)
        {
            InitializeComponent();
            PersonModel = new PersonModel();
            ManageField(id);
        }

        private void ManageField(int id)
        {
            if (id == -1) return;
            var person = PersonModel.FindById(id);
            SetUp(person);
        }

        private void SetUp(Person person)
        {
            txtName.Text = person.Name;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            txtPosition.Text = person.Position;
            txtCompany.Text = person.CompanyName;
            txtStreetAddress.Text = person.StreetAddress;
            txtCity.Text = person.City;
            pictureBox.ImageLocation = Helper.UploadedUrl(person.ImageUrl);
            btnManage.Text = "Update";
        }

        private Person Assign()
        {
            personBuilder = PersonBuilder.New
                .
            txtName.Text = person.Name;
            txtEmail.Text = person.Email;
            txtPhone.Text = person.Phone;
            txtPosition.Text = person.Position;
            txtCompany.Text = person.CompanyName;
            txtStreetAddress.Text = person.StreetAddress;
            txtCity.Text = person.City;
            pictureBox.ImageLocation = Helper.UploadedUrl(person.ImageUrl);
            btnManage.Text = "Update";
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (btnManage.Text == "Update")
            {
                PersonModel.Update()
            }
            else
            {

            }
        }
    }
}
