using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Data_Access_Layer
{
    public class clsEmployeeData
    {
        public static bool GetEmployeeInfoByID(int employeeID, ref short Salary, ref DateTime HireDate
            , ref DateTime ResignationDate, ref bool IsActive, ref int PersonID, ref int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeByEmployeeID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            Salary = (short)reader["Salary"];
                            HireDate = (DateTime)reader["HireDate"];
                            if(reader["ResignationDate"] != DBNull.Value)
                                ResignationDate = (DateTime)reader["ResignationDate"];
                            else
                            {

                                ResignationDate = DateTime.MinValue;

                            }

                            IsActive = (bool)reader["IsActive"];
                            PersonID = (int)reader["PersonID"];
                            if (reader["UserID"] != DBNull.Value)
                                UserID = (int)reader["UserID"];
                            else
                                UserID = -1;
                        }
                        reader.Close();

                        return true;
                    }

                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");

            }
            return false;
        }
        public static bool GetEmployeeInfoByUserID(int userID, ref int EmployeeID, ref short Salary, ref DateTime HireDate
            , ref DateTime ResignationDate, ref bool IsActive, ref int PersonID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeByUserID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            EmployeeID = (int)reader["EmployeeID"];
                            Salary = (short)reader["Salary"];
                            HireDate = (DateTime)reader["HireDate"];
                            ResignationDate = (DateTime)reader["ResignationDate"];
                            IsActive = (bool)reader["IsActive"];
                            PersonID = (int)reader["PersonID"];
                        }
                        reader.Close();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }
        public static bool GetEmployeeInfoByPersonID(int personID,ref int EmployeeID , ref short Salary, ref DateTime HireDate
            , ref DateTime ResignationDate, ref bool IsActive, ref int UserID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeByPersonID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", personID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            EmployeeID = (int)reader["EmpID"];
                            Salary = (short)reader["Salary"];
                            HireDate = (DateTime)reader["HireDate"];
                            if (reader["ResignationDate"] != DBNull.Value)
                                ResignationDate = (DateTime)reader["ResignationDate"];
                            else
                            {
                                ResignationDate = DateTime.MinValue;
                            }
                         
                            IsActive = (bool)reader["IsActive"];
                            if (reader["UserID"] != DBNull.Value)
                                UserID = (int)reader["UserID"];
                            else
                                UserID = -1;
                            reader.Close();
                            return true;
                        }
                        
                       
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }
        public static int AddNewEmployee(int PersonID, int UserID, short Salary, DateTime HireDate
            , DateTime ResignationDate, bool IsActive)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AddNewEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@Salary", Salary);
                        cmd.Parameters.AddWithValue("@HireDate", HireDate);
                        if (ResignationDate != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@ResignationDate", ResignationDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ResignationDate", DBNull.Value);
                        }
                            
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);

                    object result = cmd.ExecuteScalar();
                        int EmployeeID = Convert.ToInt32(result);

                        return EmployeeID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return -1;
        }

        public static bool UpdateEmployee(int EmployeeID, int PersonID, int UserID, short Salary, DateTime HireDate
            , DateTime ResignationDate, bool IsActive)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        cmd.Parameters.AddWithValue("@Salary", Salary);
                        cmd.Parameters.AddWithValue("@HireDate", HireDate);
                        if (ResignationDate != DateTime.MinValue)
                        {
                            cmd.Parameters.AddWithValue("@ResignationDate", ResignationDate);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@ResignationDate", DBNull.Value);
                        }
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }

        public static bool DeleteEmployee(int EmployeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpID", EmployeeID);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }

        public static DataTable GetAllEmployees()
        {
            DataTable dtEmployees = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dtEmployees);
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return dtEmployees;
        }

        public static bool IsEmployeeActive(int employeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_IsEmployeeActive", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        bool IsActive = (bool)reader["IsExist"];
                        reader.Close();
                        return IsActive;
                       
                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }

        public static bool DeActivateEmployee(int employeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DesActiveEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                       int RowAffected =  cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }
        public static bool ActivateEmployee(int employeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ActivateEmployee", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                       int RowAffected =  cmd.ExecuteNonQuery();
                        if (RowAffected > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }

        public static bool IsEmployeeExistByPersonID(int PersonID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_IsEmployeeExistByPersonID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@PersonID", PersonID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            bool IsExist = (bool)reader["IsExist"];
                            reader.Close();
                            return IsExist;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }
    }
}
