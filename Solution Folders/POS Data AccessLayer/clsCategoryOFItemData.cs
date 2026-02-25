using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Data_Access_Layer
{
    public class clsCategoryOFItemData
    {

         static public  bool GetCategoryOfItemInfoByID(int CategoryOfItemID, ref string CategoryOfItemName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetCategoryInfoByID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryOfItemID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            CategoryOfItemName = reader["CategoryName"].ToString();
                           
                            return true;
                        }
                    }
                }
            }
                catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CS", "Application");
                            }
            return false;
        }
        public static int AddNewCategoryOfItem(string CategoryOfItemName)
        {
            int newCategoryOfItemId = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AddNewCategory", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryName", CategoryOfItemName);
                         object Result = cmd.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int id))
                        {
                            newCategoryOfItemId = id;
                        }
                        return newCategoryOfItemId;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return -1;
        }

        public static bool UpdateCategoryOfItem(int CategoryOfItemID, string CategoryOfItemName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateCategory", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryOfItemID);
                        cmd.Parameters.AddWithValue("@CategoryName", CategoryOfItemName);
                       
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


       

        public static DataTable GetAllCategoryOfItems()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllCategories", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return dt;
        }
        public static bool DeleteCategoryOfItem(int CategoryOfItemID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteCategory", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryOfItemID);
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
    }
}
