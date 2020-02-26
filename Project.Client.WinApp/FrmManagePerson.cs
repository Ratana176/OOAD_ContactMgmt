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
        private readonly PersonModel _personModel;
        public FrmManagePerson(int id = -1)
        {
            InitializeComponent();
            _personModel = new PersonModel();
            ManageField(id);
        }

        private void ManageField(int id)
        {
            if (id == -1) return;
            var person = _personModel.FindById(id);
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
            var path = pictureBox.ImageLocation;
            path = path.Substring(path.LastIndexOf("\\", StringComparison.Ordinal)).Remove(0, 1);
            
            var person = PersonBuilderDirector.Create()
                .HasName(txtName.Text)
                .HasEmail(txtEmail.Text)
                .HasPhone(txtPhone.Text)
                .HasImage(path)
                .At(txtStreetAddress.Text)
                .AsA(txtPosition.Text)
                .WorkedWith(txtCompany.Text)
                .In(txtCity.Text)
                .Builder();
            return person;
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (btnManage.Text == "Update")
            {
                _personModel.Update(Assign());
            }
            else
            {
                _personModel.Save(Assign());
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog(){ Title = @"Open Image", Filter = @"Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG"})
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                pictureBox.ImageLocation = openFileDialog.FileName;
                pictureBox.Image.Save((@"Upload\" + openFileDialog.SafeFileName));
            }
        }
    }
}
