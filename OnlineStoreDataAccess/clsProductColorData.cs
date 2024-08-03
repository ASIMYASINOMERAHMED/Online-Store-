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
    public static class clsProductColorData
    {
        public static int AddNewProductColor(string Color, int ProductID)
        {
            int ColorID = -1;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewProductColor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@ProductID", ProductID);

                    SqlParameter outputIdParam = new SqlParameter("@NewColorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        ColorID = (int)command.Parameters["@NewColorID"].Value;

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
            return ColorID;

        }
        public static bool UpdateProductColor(string Color, int ProductID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateProductColor", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Color", Color);
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
        public static string GetAllProductColors(int ProductID)
        {
            string Colors = "";

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllProductColors", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    try
                    {
                        connection.Open();

                        object Result = command.ExecuteScalar();

                        if (Result!=null)
                        {
                            Colors = (string)Result;
                        }


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

            return Colors;
        }
        public static bool FindProductColorByID(int ProductID, ref int ColorsID, ref string Colors)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindProductColorByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            ColorsID = (int)reader["ColorID"];
                            Colors = (string)reader["Color"];
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
