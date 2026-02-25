using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BusinessLayer
{
    public class clsPhoneNumbers
    {
        enMode _Mode;
        public int _PhoneNumberID { get; set; }
        public int _PersonID { get; set; }
        public string _PhoneNumber { get; set; }

        public string _NewPhoneNumber { get; set; }

        public clsPhoneNumbers()
        {
            _PhoneNumberID = 0;
            _PersonID = 0;
            _PhoneNumber = string.Empty;
            _Mode = enMode.AddNew;
        }
        public clsPhoneNumbers(int phoneNumberID, int personID, string phoneNumber)
        {
            _PhoneNumberID = phoneNumberID;
            _PersonID = personID;
            _PhoneNumber = phoneNumber;
            _Mode = enMode.Update;
        }

        public static DataTable GetPhoneNumbersByPersonID(int personID)
        {
            return CS_Data_Access_Layer.clsPhoneNumberData.GetPhoneNumbersByPersonID(personID);
        }

        private bool AddNewNumber()
        {
            return CS_Data_Access_Layer.clsPhoneNumberData.AddPhoneNumber(_PersonID, _PhoneNumber);
        }
        private bool UpdatePhoneNumber()
        {
            return CS_Data_Access_Layer.clsPhoneNumberData.UpdatePhoneNumber(_PersonID, _PhoneNumber, _NewPhoneNumber);
        }
        public bool DeletePhoneNumber()
        {
            return CS_Data_Access_Layer.clsPhoneNumberData.DeletePhoneNumber(_PersonID, _PhoneNumber);



        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    return AddNewNumber();
                case enMode.Update:
                    return UpdatePhoneNumber();
            }
            return false;




        }
    }
}
