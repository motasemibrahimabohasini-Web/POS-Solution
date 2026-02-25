using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Data_Access_Layer
{
    public class clsShiftData
    {
        public static bool GetShiftInfoByID(int ShiftID , ref int EmployeeID , ref DateTime ComingDate , ref DateTime ResignationDate , ref bool IsInVacation)
        {
            try 
            { 
             using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
             {
                 connection.Open();
                 using (SqlCommand command = new SqlCommand("sp_GetShiftInfoByID", connection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     command.Parameters.AddWithValue("@ShiftID", ShiftID);
                     SqlDataReader reader = command.ExecuteReader();
                     if (reader.Read())
                     {
                         EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                         ComingDate = Convert.ToDateTime(reader["ComingDate"]);
                         ResignationDate = Convert.ToDateTime(reader["ResignationDate"]);
                         IsInVacation = Convert.ToBoolean(reader["IsInVacation"]);
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
        public static int AddNewShift(int EmployeeID , DateTime ComingDate , DateTime ResignationDate , bool IsInVacation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AddNewShift", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.Parameters.AddWithValue("@ComingDate", ComingDate);
                        cmd.Parameters.AddWithValue("@ResignationDate", ResignationDate);
                        cmd.Parameters.AddWithValue("@IsInVacation", IsInVacation);
                        SqlParameter outParam = new SqlParameter("@ShiftID", System.Data.SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outParam);
                        cmd.ExecuteNonQuery();
                        return (int)outParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
                
            }
            return -1;
        }
        public static bool UpdateShift(int ShiftID, int EmployeeID, DateTime ComingDate, DateTime ResignationDate, bool IsInVacation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateShift", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                        cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
                        cmd.Parameters.AddWithValue("@ComingDate", ComingDate);
                        cmd.Parameters.AddWithValue("@ResignationDate", ResignationDate);
                        cmd.Parameters.AddWithValue("@IsInVacation", IsInVacation);
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }
        public static bool DeleteShift(int ShiftID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteShift", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ShiftID", ShiftID);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return false;
        }

        //public static bool IsEmployeeInVacation(int EmployeeID)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmd = new SqlCommand("sp_IsEmployeeInVacation", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        //                SqlParameter outParam = new SqlParameter("@IsInVacation", System.Data.SqlDbType.Bit)
        //                {
        //                    Direction = System.Data.ParameterDirection.Output
        //                };
        //                cmd.Parameters.Add(outParam);
        //                cmd.ExecuteNonQuery();
        //                return (bool)outParam.Value;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
        //    }
        //    return false;
        //}

        //public static DateTime? GetEmployeeComingDate(int EmployeeID)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeComingDate", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        //                SqlParameter outParam = new SqlParameter("@ComingDate", System.Data.SqlDbType.DateTime)
        //                {
        //                    Direction = System.Data.ParameterDirection.Output
        //                };
        //                cmd.Parameters.Add(outParam);
        //                cmd.ExecuteNonQuery();
        //                if (outParam.Value != DBNull.Value)
        //                {
        //                    return (DateTime)outParam.Value;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
        //    }
        //    return null;
        //}
        //public static DateTime? GetEmployeeResignationDate(int EmployeeID)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
        //        {
        //            con.Open();
        //            using (SqlCommand cmd = new SqlCommand("sp_GetEmployeeResignationDate", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
        //                SqlParameter outParam = new SqlParameter("@ResignationDate", System.Data.SqlDbType.DateTime)
        //                {
        //                    Direction = System.Data.ParameterDirection.Output
        //                };
        //                cmd.Parameters.Add(outParam);
        //                cmd.ExecuteNonQuery();
        //                if (outParam.Value != DBNull.Value)
        //                {
        //                    return (DateTime)outParam.Value;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
        //    }
        //    return null;
        //}
        public static DataTable GetAllShifts()
        {
            DataTable shiftsTable = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllShifts", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(shiftsTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return shiftsTable;
        }
    }
}
