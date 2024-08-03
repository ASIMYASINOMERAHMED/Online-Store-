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
    public static class clsOrderItemsData
    {
        public static bool AddNewOrderItem(int OrderID, int ProductID, int Quantity,string Color,string Size, decimal Price, decimal TotalItemsPrice)
        {
            int rowAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_AddNewOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@Size", Size);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

                    try
                    {
                        connection.Open();
                        rowAffected = command.ExecuteNonQuery();
                        
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

            return (rowAffected > 0);
        }

        public static bool UpdateOrderItem(int OrderID, int ProductID, int Quantity, string Color, string Size, decimal Price, decimal TotalItemsPrice)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_UpdateOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@Size", Size);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@TotalItemsPrice", TotalItemsPrice);

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

        public static bool FindOrderItemByOrderIDAndProductID(int OrderID, int ProductID, ref int Quantity,ref string Color,ref string Size,ref decimal Price, ref decimal TotalItemsPrice)
        {
            bool IsFound = false;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindOrderItemByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderID", OrderID);
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            IsFound = true;
                            Quantity = (int)reader["Quantity"];
                            Color = (string)reader["Color"];
                            Size = (string)reader["Size"];
                            Price = (decimal)reader["Price"];
                            TotalItemsPrice = (decimal)reader["TotalItemsPrice"];
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

        public static bool DeleteOrderItem(int ProductID)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_DeleteOrderItem", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);

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
        public static DataTable GetAllOrderItems(int OrderID)
        {
                DataTable dt = new DataTable();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetAllOrderItemsByOrderID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@OrderID", @OrderID);
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
