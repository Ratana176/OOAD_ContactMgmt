using Project.Client.WinApp.Domain.Entities;
using Project.Client.WinApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Client.WinApp
{
    public partial class FrmManagePerson : Form
    {
        private readonly PersonModel _personModel;
        private readonly int _id;
        private string _imagePath;
        public FrmManagePerson(int id = -1)
        {
            InitializeComponent();
            _personModel = new PersonModel();
            this._id = id;
            ManageField();
        }

        private void ManageField()
        {
            if (this._id == -1) return;
            var person = _personModel.FindById(this._id);
            SetUp(person);
        }

        public int ShowForm()
        {
            this.ShowDialog();
            return this._id;
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
            var person = PersonBuilderDirector.Create()
                .HasId(this._id)
                .HasName(txtName.Text)
                .HasEmail(txtEmail.Text)
                .HasPhone(txtPhone.Text)
                .HasImage(Path.GetFileName(pictureBox.ImageLocation))
                .At(txtStreetAddress.Text)
                .AsA(txtPosition.Text)
                .WorkedWith(txtCompany.Text)
                .In(txtCity.Text)
                .Builder();
            return person;
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if( _imagePath != null)
            {
                Helper.SaveImage(_imagePath);
            }
            if (btnManage.Text == "Update")
            {
                if (_personModel.Update(Assign()) > 0)
                {
                    MessageBox.Show("Updated");
                }
            }
            else
            {
                if(_personModel.Save(Assign())> 0)
                {
                    MessageBox.Show("Insertd");
                }
            }
            this.Close();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog(){ Title = @"Open Image", Filter = @"Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"})
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    _imagePath = null;
                    return;
                }
                pictureBox.ImageLocation = openFileDialog.FileName;
                if (!Directory.Exists(Environment.CurrentDirectory + @"\Upload")) Directory.CreateDirectory(Environment.CurrentDirectory + @"\Upload");
                _imagePath = openFileDialog.FileName;
            }
        }


    }
}
