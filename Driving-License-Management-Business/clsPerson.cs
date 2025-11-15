using Driving_License_Management_DataAccess;
using Driving_License_Management_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Driving_License_Management_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }

        }
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gender { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }
        public string CountryName { set; get; }
        private string _ImagePath;

        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        public clsPerson()
        {
            PersonID = -1;
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            NationalNo = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now.AddYears(-18);
            Gender = 0;
            NationalityCountryID = 0;
            CountryName = "";
            ImagePath = "";
            Mode = enMode.AddNew;
        }

        private clsPerson(PersonDTO person)
        {
            PersonID = person.PersonID;
            FirstName = person.FirstName;
            SecondName = person.SecondName;
            ThirdName = person.ThirdName;
            LastName = person.LastName;
            NationalNo = person.NationalNo;
            Email = person.Email;
            Phone = person.Phone;
            Address = person.Address;
            DateOfBirth = person.DateOfBirth;
            Gender = person.Gender;
            NationalityCountryID = person.NationalityCountryID;
            CountryName = person.CountryName;
            ImagePath = person.ImagePath;

            Mode = enMode.Update;
        }

        public static List<PersonDTO> GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static clsPerson Find(int PersonID)
        {
            PersonDTO person = clsPersonData.GetPersonByID(PersonID);
            return new clsPerson(person);
        }

        public static clsPerson Find(string NationalNo)
        {
            PersonDTO person = clsPersonData.GetPersonByNationalNo(NationalNo);
            return new clsPerson(person);
        }

        private bool _AddNewPerson()
        {
            PersonDTO person = new PersonDTO
            {
                PersonID = this.PersonID,
                NationalNo = this.NationalNo,
                FirstName = this.FirstName,
                SecondName = this.SecondName,
                ThirdName = this.ThirdName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email,
                NationalityCountryID = this.NationalityCountryID,
                ImagePath = this.ImagePath
            };
            this.PersonID = clsPersonData.AddNewPerson(person);
            return (this.PersonID != -1);
        }

        private bool _UpdatePerson()
        {
            PersonDTO person = new PersonDTO
            {
                PersonID = this.PersonID,
                NationalNo = this.NationalNo,
                FirstName = this.FirstName,
                SecondName = this.SecondName,
                ThirdName = this.ThirdName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                Gender = this.Gender,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email,
                NationalityCountryID = this.NationalityCountryID,
                ImagePath = this.ImagePath
            };
            return clsPersonData.UpdatePerson(person);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }

        public static bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
