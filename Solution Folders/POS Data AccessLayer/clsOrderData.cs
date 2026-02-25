using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CS_Data_Access_Layer
{
    public class clsOrderData
    {
        public static int AddNewOrder(float TotalAmount, DateTime ReleaseDate, int ReleasedByUserID)
        {
            int NewOrderID = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_AddNewOrder", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TotalAmount", TotalAmount);
                        command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                        command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                        SqlParameter outputIdParam = new SqlParameter("@NeworderID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        NewOrderID = (int)outputIdParam.Value;
                        return NewOrderID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteToRegistry(clsUtil.ExceptionMessageToString(ex), System.Diagnostics.EventLogEntryType.Error, "CA", "Application");
            }
            return -1;
        }


        public static bool GetOrderInfo(int OrderID, ref float TotalAmount, ref DateTime ReleaseDate, ref int ReleasedByUserID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetOrderByOrderID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", OrderID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {


                                TotalAmount = Convert.ToSingle(reader["TotalAmount"]);
                                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]);
                                ReleasedByUserID = Convert.ToInt32(reader["ReleasedByUserID"]);
                                return true;
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

            return false;
        }

        public static DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetAllOrders", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return dt;
        }

       
    }
}
