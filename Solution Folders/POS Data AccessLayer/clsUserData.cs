using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CS_Data_Access_Layer
{
    public class clsUserData
    {
        public class dtoPermissions
        {
            public bool _CanManageUsers {  get; set; }
            public bool _CanManageEmployees {  get; set; }
            public bool _CanManageItems  { get; set; }
            public bool _CanManageOrders {  get; set; }
            public bool _CanManageSales {  get; set; }
            public bool _CanManageShifts {  get; set; }

            public dtoPermissions(bool canManageUsers, bool canManageEmployees, bool canManageItems, bool canManageOrders, bool canManageSales, bool canManageShifts)
            {
                this._CanManageUsers = canManageUsers;
                this._CanManageEmployees = canManageEmployees;
                this._CanManageItems = canManageItems;
                this._CanManageOrders = canManageOrders;
                this._CanManageSales = canManageSales;
                this._CanManageShifts = canManageShifts;
            }
        }
        public static bool GetUserInfoByID(int UserID,
            ref int EmployeeID, ref string UserName,
            ref string Password, ref bool IsActive , ref int RoleID )
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetUserByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                EmployeeID = (int)reader["EmployeeID"];
                                UserName = reader["UserName"] as string;
                                Password = reader["Password"] as string;
                                IsActive = (bool)reader["IsActive"];
                                RoleID = (int)reader["RoleID"];



                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }

            return isFound;
        }
        public static bool GetUserInfoByEmployeeID(int EmployeeID,
           ref int UserID, ref string UserName,
           ref string Password, ref bool IsActive,
           ref int RoleID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetUserByEmployeeID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                UserName = reader["UserName"] as string;
                                Password = reader["Password"] as string;
                                IsActive = (bool)reader["IsActive"];
                                RoleID = (int)reader["RoleID"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return isFound;
        }
        public static bool GetUserInfoByPersonID( int PersonID,ref int EmployeeID,
           ref int UserID, ref string UserName,
           ref string Password, ref bool IsActive,
           ref int RoleID)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetUserByEmployeeID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                UserID = (int)reader["UserID"];
                                EmployeeID = (int)reader["EmployeeID"];
                                UserName = reader["UserName"] as string;
                                Password = reader["Password"] as string;
                                IsActive = (bool)reader["IsActive"];
                                RoleID = (int)reader["RoleID"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return isFound;
        }

        public static int AddNewUser(int EmployeeID, string UserName, string Password, bool IsActive, int RoleID)
        {
            int newUserID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@RoleID", RoleID);

                       

                        connection.Open();
                        object Result = command.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int id))
                        {
                            newUserID = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }

            return newUserID;
        }

        public static DataTable GetAllUsers()
        {
            DataTable UsersTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(UsersTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return UsersTable;
        }
        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive, int RoleID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", UserID); command.Parameters.AddWithValue("@UserName", UserName);
                        command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 50)
                                      .Value = Password;
                        command.Parameters.AddWithValue("@IsActive", IsActive);
                        command.Parameters.AddWithValue("@RoleID", RoleID);
                      
                        



                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
                return false;
            }

         
        }

        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_DeleteUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }

            return rowsAffected > 0;
        }

        public static bool IsUserExist(int UserID)
        {
            bool exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_IsUserExistByUserID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);

                        SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        exists = (bool)outputParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }

            return exists;
        }
        public static bool IsUserExistByEmployeeID(int EmployeeID)
        {
            bool exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_IsUserExistByEmployeeID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        connection.Open();
                        command.ExecuteNonQuery();
                        exists = (bool)outputParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return exists;

        }
        public static bool IsUserExistByUsername(string Username)
        {
            bool exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_IsUserExistByUsername", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", Username);
                        SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        connection.Open();
                        command.ExecuteNonQuery();
                        exists = (bool)outputParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return exists;

        }
        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_IsUserExistByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", PersonID);
                        SqlParameter outputParam = new SqlParameter("@Exists", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputParam);
                        connection.Open();
                        command.ExecuteNonQuery();
                        exists = Convert.ToBoolean( outputParam.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return exists;

        }
        public static bool Login(string Username , string HashPassword)
        {
            bool IsLogged = false;
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Login",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username",Username);
                        cmd.Parameters.AddWithValue("@HashPassword", HashPassword);
                        con.Open();
                        IsLogged = Convert.ToBoolean( cmd.ExecuteScalar());
                       

                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");

            }

            return IsLogged;

        }

        public static dtoPermissions GetPermissionsIDByUserID(int UserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetUserPermisiions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserID", UserID);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new dtoPermissions((bool)reader[0], (bool)reader[1], (bool)reader[2], (bool)reader[3], (bool)reader[4], (bool)reader[5]);
                               
                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return null;
        }
    }

} 
  
