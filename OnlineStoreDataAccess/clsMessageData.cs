using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStoreDataAccess
{
    public static class clsMessageData
    {
        public static int AddNewMessage(int CustomerID, string Message,DateTime dateTime)
        {
            int MessageID = -1;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewMessage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    command.Parameters.AddWithValue("@Message", Message);
                    command.Parameters.AddWithValue("@dateTime", dateTime);
                    SqlParameter outputIdParam = new SqlParameter("@NewMessageID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        MessageID = (int)command.Parameters["@NewMessageID"].Value;

                    }

                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);

                    }

                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return MessageID;

        }
        public static bool UpdateMessage(int MessageID, string Message)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateMesaage", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MessageID", MessageID);
                    command.Parameters.AddWithValue("@Message", Message);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);
                        return false;
                    }

                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return (rowsAffected > 0);
        }
        public static bool DeleteMessage(int MessageID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteMessage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MessageID", MessageID);

                    try
                    {
                        connection.Open();

                        rowsAffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);
                    }
                    finally
                    {

                        connection.Close();

                    }
                }
            }
            return (rowsAffected > 0);

        }
        public static bool FindMessageByID(int MessageID,ref  int CustomerID,ref string Message,ref DateTime dateTime)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindMessageByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MessageID", MessageID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            CustomerID = (int)reader["CustomerID"];
                            Message = (string)reader["Message"];
                            dateTime = (DateTime)reader["DateTime"];

                        }
                        else
                        {
                            IsFound = false;
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {

                        clsConfigrationSettings._LogErorr(ex);
                        IsFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return IsFound;
        }
        public static DataTable GetAllMessages()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllMessages", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();


                    }

                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }

            return dt;
        }
        public static DataTable GetAllMessagesForCustomerID(int CustomerID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllMessagesForCustomerID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    try
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            dt.Load(reader);
                        }

                        reader.Close();


                    }

                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }

            return dt;
        }
    }
}
