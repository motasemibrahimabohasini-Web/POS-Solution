using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Data_Access_Layer;

namespace CS_BusinessLayer
{
    internal enum enMode { AddNew = 1, Update = 2 }
    public class clsPerson
    {
        enMode _Mode;
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string _FullName { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string _CountryName { get; set; }


        public clsPerson()
        {
            PersonID = 0;
            NationalNo = string.Empty;
            _FullName = string.Empty;
            CountryID = 0;
            ImagePath = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Gender = false;
            Address = string.Empty;
            Email = string.Empty;
            _CountryName = string.Empty;
            Phone = "";
            _Mode = enMode.AddNew;
        }
        public clsPerson(int personID, string nationalNo, string imagePath, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, bool gender, int countryID, string address, string email , string Phone)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            _FullName = firstName + " " + secondName + " " + thirdName + " " + lastName;
            CountryID = countryID;
            ImagePath = imagePath;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Email = email;
            _CountryName = clsCountryData.GetCountryNameByID(countryID);
             this.Phone = Phone;
            _Mode = enMode.Update;

        }

        private bool AddNewPerson()
        {
            int newPersonID = clsPersonData.AddNewPerson(NationalNo, CountryID, ImagePath, FirstName, SecondName, ThirdName, LastName
                , DateOfBirth, Gender, Address, Email  , Phone);
            if (newPersonID > 0)
            {
                PersonID = newPersonID;
                return true;
            }
            return false;
        }
        private bool UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, NationalNo, CountryID, ImagePath, FirstName, SecondName, ThirdName
                , LastName, DateOfBirth, Gender, Address, Email);
        }

        public static clsPerson Find(int personID)
        {
            string nationalNo = string.Empty;
            string imagePath = string.Empty;
            string firstName = string.Empty;
            string secondName = string.Empty;
            string thirdName = string.Empty;
            string lastName = string.Empty;
            DateTime dateOfBirth = DateTime.MinValue;
            bool gender = false;
            string address = string.Empty;
            string email = string.Empty;
            int countryID = 0;
            string Phone = string.Empty;
            try
            {
                Phone = clsPhoneNumbers.GetPhoneNumbersByPersonID(personID).Rows[0][2].ToString();
            }
            catch
            {
                Phone = string.Empty;
            }
            

            if (clsPersonData.GetPersonInfoByID(personID, ref nationalNo, ref countryID, ref imagePath, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email))
            {
                return new clsPerson(personID, nationalNo, imagePath, firstName, secondName, thirdName, lastName, dateOfBirth, gender, countryID, address, email , Phone);
            }
            return null;
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static bool Delete(int personID)
        {
            return clsPersonData.DeletePerson(personID);
        }
        public static bool IsPersonExistByPersonID(int personID)
        {
            return clsPersonData.IsPersonExist(personID);
        }
        public bool Save()
        {
            if (_Mode == enMode.AddNew)
            {
                return AddNewPerson();
            }
            else if (_Mode == enMode.Update)
            {
                return UpdatePerson();
            }
            return false;
        }
    }
}
