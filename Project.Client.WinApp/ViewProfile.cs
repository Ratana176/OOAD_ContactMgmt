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
    public partial class ViewProfile : Form
    {
        private readonly PersonModel _personModel;
        public ViewProfile(int id)
        {
            InitializeComponent();
            _personModel = new PersonModel();
            SetupData(id);
        }

        private void SetupData(int id)
        {
            if (id == -1) return;
            var person = _personModel.FindById(id);
            SetupField(person);
        }

        private void SetupField(Person person)
        {
            lblName.Text = person.Name;
            lblEmail.Text = person.Email;
            lblPhone.Text = person.Phone;
            lblPosition.Text = person.Position;
            lblCompany.Text = person.CompanyName;
            lblStreet.Text = person.StreetAddress;
            lblCity.Text = person.City;
            if(!String.IsNullOrEmpty(person.ImageUrl))
            pictureBox.ImageLocation = Helper.UploadedUrl(person.ImageUrl);
        }
    }
}
