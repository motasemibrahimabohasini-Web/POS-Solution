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
        public class dtoOrderInfo
        {
            public int _OrderID { get; set; }
            public int _ReleasedByUserID { get; set; }
            public decimal _TotalAmount { get; set; }
            public bool _IsActive { get; set; }
            public DateTime _ReleaseDate { get; set; }

            public dtoOrderInfo(int OrderID, int ReleasedByUserID, decimal TotalAmount, bool IsActive
                  , DateTime ReleasedDate)
            {
                _OrderID = OrderID;
                _ReleasedByUserID = ReleasedByUserID;
                _TotalAmount = TotalAmount;
                _IsActive = IsActive;
                _ReleaseDate = ReleasedDate;
            }
        }
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


        public static dtoOrderInfo GetOrderInfo(int OrderID)
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
                               

                                return new dtoOrderInfo(OrderID, Convert.ToInt32(reader["UserID"])
                                    , Convert.ToDecimal(reader["TotalAmount"]), (bool)reader["IsActive"], Convert.ToDateTime(reader["ReleaseDate"]));
                                
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

        public static bool RefundOrder(int OrderID)
        {
            int RowsAffected = -1;
            try
            {
                using (SqlConnection con = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("sp_RefundOrder", con))
                    {
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        RowsAffected = cmd.ExecuteNonQuery();

                    }
                }

            }
            catch (Exception ex)
            {

                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");

            }
            return RowsAffected != -1;


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
