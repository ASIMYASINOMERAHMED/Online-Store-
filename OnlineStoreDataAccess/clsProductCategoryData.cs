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
    public static class clsProductCategoryData
    {
        public static int AddNewProductCategory(string CategoryName,string CategoryImage)
        {
            int CategoryID = -1;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);
                    command.Parameters.AddWithValue("@CategoryImage", CategoryImage);
                    SqlParameter outputIdParam = new SqlParameter("@NewCategoryID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        CategoryID = (int)command.Parameters["@NewCategoryID"].Value;

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
            return CategoryID;

        }
        public static bool UpdateProductCategory(int CategoryID, string CategoryName,string CategoryImage)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateCategory", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);
                    command.Parameters.AddWithValue("@CategoryImage", CategoryImage);
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
        public static bool FindProductCategoryByID(int CategoryID, ref string CategoryName,ref string CategoryImage)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindCategoryByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            CategoryName = (string)reader["CategoryName"];
                            CategoryImage = (string)reader["CategoryImage"];
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
        public static bool FindProductCategoryByName(string CategoryName, ref int CategoryID, ref string CategoryImage)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindCategoryByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            CategoryID = (int)reader["CategoryID"];
                            CategoryImage = (string)reader["CategoryImage"];
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
        public static bool DeleteProductCategory(int CategoryID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CategoryID", CategoryID);

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

        public static DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllCategories", connection))
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
    
        public static bool IsCategoryExist(string CategoryName)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_CheckCategoryExist", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryName", CategoryName);
                    SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.ReturnValue
                    };
                    command.Parameters.Add(returnParameter);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        isFound = (int)returnParameter.Value == 1;
                    }
                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);
                        isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return isFound;
        }
    }
}
