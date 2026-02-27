using CS_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CS_BusinessLayer
{
    public class clsUser 
    {
        enMode _Mode;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int _EmployeeID { get; set; }
        public bool IsActive { get; set; }

        public int RoleID { get; set; }
        public clsEmployee _Employee { get; set; } = new clsEmployee();
        public clsUserData.dtoPermissions dtoPermissions {  get; set; }
        public clsUser()
        {
            UserID = 0;
            UserName = string.Empty;
            Password = string.Empty;
            _EmployeeID = 0;
            IsActive = false;
            RoleID = 0;
            _Mode = enMode.AddNew;
        }
        public clsUser(int userID, string userName, string password, int employeeID, int _RoleID , bool isActive)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
            _EmployeeID = employeeID;
            IsActive = isActive;
            _Mode = enMode.Update;
            _RoleID = RoleID;
            _Employee =  clsEmployee.Find(employeeID);
            dtoPermissions = clsUserData.GetPermissionsIDByUserID(userID);
            
        }

        private bool AddNewUser()
        {
            int UserID = clsUserData.AddNewUser(_EmployeeID,UserName,Password,IsActive,RoleID);
            if (UserID != -1)
            {
                this.UserID = UserID;
                return true;
            }
            return false;
        }

        private bool UpdateUser()
        {
            return clsUserData.UpdateUser(UserID,UserName,Password,IsActive,RoleID) ;
        }

        public bool DeleteUser()
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserExist(int userID)
        {
            return clsUserData.IsUserExist(userID);
        }
        public static bool IsUserExist(string Username)
        {
            return clsUserData.IsUserExistByUsername(Username);
        }
        public static bool IsUserExistByPersonID(int PersonID)
        {
            return clsUserData.IsUserExistByPersonID(PersonID);
        }
        
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
    
        public static bool Delete(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool IsUserExistByUserEmpID(int EmployeeID)
        {
            return clsUserData.IsUserExistByEmployeeID(EmployeeID);
        }
        public static clsUser Find(int UserID)
        {
            int EmployeeID = 0;
            string UserName = string.Empty;
            string Password = string.Empty;
            bool IsActive = false;
            int RoleID = -1;

            if(clsUserData.GetUserInfoByID(UserID, ref EmployeeID, ref UserName,ref Password,ref IsActive , ref RoleID))
            {
                return new clsUser(UserID,UserName,Password,EmployeeID,RoleID,IsActive);
            }
            return null;
        }

        public static bool Login(string Username , string HashPassword)
        {
            return clsUserData.Login(Username,HashPassword);
        }
        public bool Save()
        {
            switch( _Mode ) {
                case enMode.AddNew:
                    return AddNewUser();
                 
               case enMode.Update: return UpdateUser();

            }
            return false;
        }
    }
}
