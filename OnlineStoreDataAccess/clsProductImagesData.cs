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
    public static class clsProductImagesData
    {
        public static int AddNewProductImage(string ImageUrl, short ImageOrder, int ProductID)
        {
            int ID = -1;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewProductImage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                    command.Parameters.AddWithValue("@ImageOrder", ImageOrder);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
        
                 
                    SqlParameter outputIdParam = new SqlParameter("@NewImageID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        ID = (int)command.Parameters["@NewImageID"].Value;

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
            return ID;

        }

        public static bool UpdateProductImage(int ID, string ImageUrl, short ImageOrder, int ProductID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateProductImage", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                 
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@ImageUrl", ImageUrl);
                    command.Parameters.AddWithValue("@ImageOrder", ImageOrder);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
        
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
        public static bool DeleteProductImage(int ID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteProductImage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID", ID);

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
        public static bool FindProductImageByID(int ID, ref string ImageUrl, ref short ImageOrder, ref int ProductID)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindProductImageByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID", ID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            ImageUrl = (string)reader["ImageURL"];
                            ImageOrder = (short)reader["ImageOrder"];
                            ProductID = (int)reader["ProductID"];
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
        public static DataTable GetAllImagesForProductID(int ProductID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductImagesByProductID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
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
