using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CS_Data_Access_Layer
{
    public class clsPersonData
    {

        public static bool GetPersonInfoByID(int personID,
            ref string nationalNo, 
            ref int countryID, ref string imagePath,
            ref string firstName, ref string secondName,
            ref string thirdName, ref string lastName,
            ref DateTime dateOfBirth, ref bool gender,
            ref string address, ref string email)
        {
            bool isFound = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetPersonByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;

                                nationalNo = reader["NationalNo"].ToString();
                                if (reader["CountryID"] != DBNull.Value)
                                {
                                    countryID = Convert.ToInt32(reader["CountryID"]);
                                }
                                else
                                {
                                    countryID = 0; // or any default value you prefer
                                }
                                imagePath = reader["ImagePath"].ToString();
                                firstName = reader["FirstName"].ToString();
                                secondName = reader["SecondName"].ToString();
                                thirdName = reader["ThirdName"].ToString();
                                lastName = reader["LastName"].ToString();
                                dateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                                gender = Convert.ToBoolean( reader["Gendor"]);
                                address = reader["Address"].ToString();
                                email = reader["Email"].ToString();
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

        public static int AddNewPerson(string nationalNo,  int countryID, string imagePath,
            string firstName, string secondName, string thirdName, string lastName,
            DateTime dateOfBirth, bool gender, string address, string email , string PhoneNumber )
        {
            int newPersonID = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@NationalNo", nationalNo);
                        command.Parameters.AddWithValue("@CountryID", countryID);
                        command.Parameters.AddWithValue("@ImagePath", imagePath);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@SecondName", secondName);
                        command.Parameters.AddWithValue("@ThirdName", thirdName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

                        SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newPersonID = (int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }

            return newPersonID;
        }

        public static DataTable GetAllPeople()
        {
            DataTable peopleTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_GetAllUsers", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(peopleTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = clsUtil.ExceptionMessageToString(ex);
                clsUtil.WriteToRegistry(errorMessage, System.Diagnostics.EventLogEntryType.Error, "CS_Data_Access_Layer", "Application");
            }
            return peopleTable;
        }
        public static bool UpdatePerson(int  personID, string nationalNo,int countryID, string imagePath,
            string firstName, string secondName,string  thirdName, string lastName,
            DateTime dateOfBirth, bool  gender, string  address, string email)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@NationalNo", nationalNo);
                      
                        command.Parameters.AddWithValue("@CountryID", countryID);
                        if (imagePath != null)
                        {
                            command.Parameters.AddWithValue("@ImagePath", imagePath);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                        }
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@SecondName", secondName);
                        command.Parameters.AddWithValue("@ThirdName", thirdName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@Gender", gender);
                        if (address != null)
                        {
                            command.Parameters.AddWithValue("@Address", address);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Address", DBNull.Value);
                        }
                        command.Parameters.AddWithValue("@Email", email);

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

        public static bool DeletePerson(int personID)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_DeletePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

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

        public static bool IsPersonExist(int personID)
        {
            bool exists = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_IsPersonExistByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PersonID", personID);

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
    }
}