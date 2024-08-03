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
    public static class clsNotificationCustomerData
    {
        public static DataTable GetAllCustomerNotifications()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllCustomerNotifications", connection))
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
        public static bool FindCustomerNotificationByID(int NotificationID, ref int NewProductID, ref int NewCategoryID,ref DateTime dateTime)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindCustomerNotificationByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NotificationID", NotificationID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            if (reader["NewProductID"] == DBNull.Value)
                                NewProductID = -1;
                            else
                                NewProductID = (int)reader["NewProductID"];
                            if (reader["NewCategoryID"]==DBNull.Value)
                                NewCategoryID = -1;
                            else
                                NewCategoryID = (int)reader["NewCategoryID"];
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

    }
}
