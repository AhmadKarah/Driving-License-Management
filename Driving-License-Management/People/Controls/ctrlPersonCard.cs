using Driving_License_Management.Properties;
using Driving_License_Management_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Management.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;

        public int PersonId
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID. = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            if (_Person == null)
            {
                MessageBox.Show("Person not loaded!");
                return;
            }

            llEdit.Enabled = true;
            _PersonID = _Person.PersonID;
            lbPersonID.Text = _Person.PersonID.ToString();
            lbNationalNo.Text = _Person.NationalNo;
            lbName.Text = _Person.FullName;
            lbGender.Text = _Person.Gender == 0 ? "Male" : "Female";
            lbEmail.Text = _Person.Email;
            lbPhone.Text = _Person.Phone;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            var country = clsCountry.Find(_Person.NationalityCountryID);
            lbCountry.Text = country != null ? country.CountryName : "Unknown";
            lbAddress.Text = _Person.Address;
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lbPersonID.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbName.Text = "[????]";
            lbGender.Text = "[????]";
            lbEmail.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            lbAddress.Text = "[????]";
        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
            
        }
    }
}
