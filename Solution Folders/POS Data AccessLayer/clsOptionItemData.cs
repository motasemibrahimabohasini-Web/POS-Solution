using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Data_Access_Layer
{
    public class clsOptionItemData
    {



        public static DataTable GetAllOptionsItem()
        {
            DataTable OptionItemsTable = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllOptionsItem", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(OptionItemsTable);
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return OptionItemsTable;
        }
        public static bool MergeOptionItems(DataTable OptionsItemTable , int ItemID)
        {
            
            try
            {
                using(SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand("sp_MergeItemOptions", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                      
                        SqlParameter parameter = cmd.Parameters.AddWithValue("@Options", OptionsItemTable);
                        cmd.Parameters.AddWithValue("@ItemID", ItemID);
                        parameter.TypeName = " ItemOptionsTableType";
                        parameter.SqlDbType = SqlDbType.Structured;
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
        public static bool UpdateOptionItem(int optionItemID, string optionName, decimal Price)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {

                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateOption", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OptionItemID", optionItemID);
                        cmd.Parameters.AddWithValue("@OptionName", optionName);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CS", "Application");
            }
            return false;
        }
        public static bool DeleteOptionItem(int optionItemID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteOptionItem", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OptionID", optionItemID);
                        rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CS", "Application");
            }
            return false;




        }
        public static DataTable GetOptionsItemByItemID(int itemID)
        {
            DataTable optionItemsTable = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetOptionsItemByItemID", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(optionItemsTable);
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CS", "Application");
            }
            return optionItemsTable;
        }
    }
}

