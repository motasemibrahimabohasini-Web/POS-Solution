using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CS_Data_Access_Layer
{
    public class clsItemData
    {
        public static bool GetItemInfoByID(int ItemID , ref string ItemName , ref float Price , ref bool IsActive , ref int UserID , ref int CategoryID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetItemByItemID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ItemName = reader["ItemName"].ToString();
                            Price = Convert.ToSingle(reader["Price"]);
                            IsActive =(bool) reader["IsActive"];
                            UserID = Convert.ToInt32(reader["UserID"]);
                            CategoryID = Convert.ToInt32(reader["CategoryID"]);
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
        public static DataTable GetAllItemsByCategory(int CategoryID)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetItemsByCategory", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public static int AddNewItem(string ItemName , float Price , string ImagePath , bool IsActive , int UserID , int CategoryID)
        { 
            int newItemId = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_AddNewItem", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemName", ItemName);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        if (!string.IsNullOrEmpty(ImagePath))
                            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
                        else
                        cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                        object Result = cmd.ExecuteScalar();
                        if (Result != null && int.TryParse(Result.ToString(), out int id))
                        {
                            newItemId = id;
                        }
                        return newItemId;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return -1;
        }

        public static bool UpdateItem(int ItemID, string ItemName, float Price, string ImagePath, bool IsActive, int UserID , int CategoryID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateItem", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
                        cmd.Parameters.AddWithValue("@ItemName", ItemName);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        if (!string.IsNullOrEmpty(ImagePath))
                            cmd.Parameters.AddWithValue("@ImagePath", ImagePath);
                        else
                            cmd.Parameters.AddWithValue("@ImagePath",DBNull.Value);
                        cmd.Parameters.AddWithValue("@IsActive", IsActive);
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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

        public static bool DesactivateItem(int ItemID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DesactivateItem", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
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
        public static bool ActivateItem(int ItemID)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ActivateItem", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
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
       
        public static DataTable GetAllItems()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllItems", connection))
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
        public static bool DeleteItem(int ItemID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteItem", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
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
