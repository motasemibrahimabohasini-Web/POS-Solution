using CS_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_BusinessLayer
{
    public  class clsEmployee
    {
        private enMode _Mode;
        public int _EmployeeID { get; set; }
        public int PersonID { get; set; }
        public short _Salary { get; set; }
        public DateTime _HireDate { get; set; }
        public DateTime _ResignationDate { get; set; }
        public bool _IsActive { get; set; }
        public int _HiredByUserID { get; set; }
        public clsPerson Person { get; set; } = new clsPerson();

        public clsEmployee()
        {
            _EmployeeID = 0;
            PersonID = 0;
            _Salary = 0;
            _HireDate = DateTime.MinValue;
            _ResignationDate = DateTime.MinValue;
            _IsActive = false;
            _HiredByUserID = 0;
            _Mode = enMode.AddNew;

        }

        public clsEmployee(int employeeID, int personID, short salary, DateTime hireDate, DateTime resignationDate, bool isActive, int hiredByUserID)
        {
            _EmployeeID = employeeID;
            PersonID = personID;
            _Salary = salary;
            _HireDate = hireDate;
            _ResignationDate = resignationDate;
            _IsActive = isActive;
            _HiredByUserID = hiredByUserID;
            _Mode = enMode.Update;
            Person = clsPerson.Find(personID);
        }

        public static clsEmployee Find(int employeeID)
        {
            int personID = 0;
            short salary = 0;
            DateTime hireDate = DateTime.MinValue;
            DateTime resignationDate = DateTime.MinValue;
            bool isActive = false;
            int hiredByUserID = 0;
            if (clsEmployeeData.GetEmployeeInfoByID(employeeID, ref salary, ref hireDate, ref resignationDate, ref isActive, ref personID, ref hiredByUserID))
            {
                return new clsEmployee(employeeID, personID, salary, hireDate, resignationDate, isActive, hiredByUserID);
            }
            return null;

        }

        public static clsEmployee FindByPersonID(int PersonID)
        {
            int EmployeeID = 0;
            short salary = 0;
            DateTime hireDate = DateTime.MinValue;
            DateTime resignationDate = DateTime.MinValue;
            bool isActive = false;
            int hiredByUserID = 0;
            if (clsEmployeeData.GetEmployeeInfoByPersonID(PersonID, ref EmployeeID, ref salary, ref hireDate, ref resignationDate, ref isActive, ref hiredByUserID))
            {
                return new clsEmployee(EmployeeID, PersonID, salary, hireDate, resignationDate, isActive, hiredByUserID);
            }
            return null;

        }

        public static clsEmployee FindByUserID(int UserID)
        {
            int EmployeeID = 0;
            int PersonID = 0;
            short salary = 0;
            DateTime hireDate = DateTime.MinValue;
            DateTime resignationDate = DateTime.MinValue;
            bool isActive = false;
            int hiredByUserID = 0;
            if (clsEmployeeData.GetEmployeeInfoByUserID(UserID, ref EmployeeID, ref salary, ref hireDate, ref resignationDate, ref isActive, ref PersonID))
            {
                return new clsEmployee(EmployeeID, PersonID, salary, hireDate, resignationDate, isActive, hiredByUserID);
            }
            return null;

        }
        public static System.Data.DataTable GetAllEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }
        public static bool IsEmployeeActive(int EmployeeID)
        {
            return clsEmployeeData.IsEmployeeActive(EmployeeID);
        }
        private bool AddNewEmployee()
        {
           int EmployeeID = clsEmployeeData.AddNewEmployee(PersonID,_HiredByUserID,_Salary,_HireDate,_ResignationDate,_IsActive);
            if (EmployeeID != -1)
            {
                _EmployeeID = EmployeeID;
                return true;
            }
            return false;
        }
        private bool UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(_EmployeeID, PersonID, _HiredByUserID, _Salary, _HireDate, _ResignationDate, _IsActive);

        }
        public bool DeleteEmployee()
        {
            return clsEmployeeData.DeleteEmployee(_EmployeeID);
        }
        public static bool DeleteEmployee(int EmployeeID)
        {
            return clsEmployeeData.DeleteEmployee(EmployeeID);
        }
        public  bool ActivateEmployee()
        {
            if( clsEmployeeData.ActivateEmployee(_EmployeeID))
            {
                _IsActive = true;
                return true;
            }
            return false;
            
        }
        public  bool DeactivateEmployee()
        {
            if (clsEmployeeData.DeActivateEmployee(_EmployeeID))
            {
                _IsActive = false;
                return true;
            }
            return false;
        }
        public static bool IsEmployeeExistsByPersonID(int PersonID)
        {
            return clsEmployeeData.IsEmployeeExistByPersonID(PersonID);
        }

        public bool Save()
        {
            switch(_Mode) {
                case enMode.AddNew:
                    return AddNewEmployee();
                    
                case enMode.Update:
                    return UpdateEmployee();
            }
            return false;
        }
    }
}
