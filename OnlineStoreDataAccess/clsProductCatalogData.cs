using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OnlineStoreDataAccess
{
    public static class clsProductCatalogData
    {
        public static int AddNewProductCatalog(string ProductName, string Description,string LongDescription, decimal Price, int QuantityInStock
            , int CategoryID,int? SubCategoryID,string ImageURL,string VideoURL,int Discount)
        {
            int ProductID = -1;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewProductCatalog", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@LongDescription", @LongDescription);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                    if(Discount==0)
                        command.Parameters.AddWithValue("@Discount", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Discount", Discount);
                    if (ImageURL==string.Empty)
                        command.Parameters.AddWithValue("@ImageURL", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImageURL", ImageURL);
                    if (VideoURL == string.Empty)
                        command.Parameters.AddWithValue("@VideoURL", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@VideoURL", VideoURL);
                    SqlParameter outputIdParam = new SqlParameter("@NewProductID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputIdParam);
                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        ProductID = (int)command.Parameters["@NewProductID"].Value;

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
            return ProductID;

        }

        public static bool UpdateProductCatalog(int ProductID,string ProductName, string Description,string LongDescription, decimal Price, int QuantityInStock, int CategoryID,int SubCategoryID, string ImageURL,string VideoURL,int Discount)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateProductCatalog", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@LongDescription", @LongDescription);
                    command.Parameters.AddWithValue("@Price", Price);
                    command.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                    if (Discount == 0)
                        command.Parameters.AddWithValue("@Discount", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@Discount", Discount);
                    if (ImageURL == string.Empty)
                        command.Parameters.AddWithValue("@ImageURL", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@ImageURL", ImageURL);
                    if (VideoURL == string.Empty)
                        command.Parameters.AddWithValue("@VideoURL", DBNull.Value);
                    else
                        command.Parameters.AddWithValue("@VideoURL", VideoURL);
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
        public static bool AddToFavourit(int ProductID,int CustomerID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddToFavourit", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public static bool RemoveFromFavourit(int ProductID,int CustomerID)
        {
            int rowsAffected = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_RemoveFromFavourit", connection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
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
        public static bool FindProductCatalogByID(int ProductID,ref string ProductName,ref string Description,ref string LongDescription,ref decimal Price,ref int QuantityInStock,ref int CategoryID,ref int SubCategoryID, ref string ImageURL,ref string VideoURL,ref int Discount)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindProductCatalogByID", connection))
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
                            ProductName = (string)reader["ProductName"];
                            Description = (string)reader["Description"];
                            LongDescription = (string)reader["LongDescription"];
                            Price = (decimal)reader["Price"];
                            QuantityInStock = (int)reader["QuantityInStock"];
                            CategoryID = (int)reader["CategoryID"];
                            if (reader["SubCategoryID"] == DBNull.Value)
                                SubCategoryID = -1;
                            else
                               SubCategoryID = (int)reader["SubCategoryID"];
                            if (reader["ImageURL"] == DBNull.Value)
                                ImageURL = "";
                            else
                                ImageURL = (string)reader["ImageURL"];
                            if (reader["VideoURL"] == DBNull.Value)
                                VideoURL = "";
                            else
                                VideoURL = (string)reader["VideoURL"];
                            if (reader["Discount"] == DBNull.Value)
                                Discount = 0;
                            else
                                Discount = (int)reader["Discount"];
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
        public static bool IsProductAddedToFavourite(int ProductID,int CustomerID)
        {
            bool AddedToFavourite = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_IsProductAddedToFavourite", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductID", ProductID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && bool.TryParse(result.ToString(), out bool IsAdded))
                            AddedToFavourite = IsAdded;
                        else
                            AddedToFavourite = false;

                    }
                    catch (Exception ex)
                    {
                        clsConfigrationSettings._LogErorr(ex);
                        return AddedToFavourite;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
            return AddedToFavourite;
        }
        public static bool FindProductCatalogByName(string ProductName,ref int ProductID, ref string Description, ref string LongDescription, ref decimal Price, ref int QuantityInStock, ref int CategoryID,ref int SubCategoryID, ref string ImageURL, ref string VideoURL, ref int Discount)
        {
            bool IsFound = false;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_FindProductCatalogByName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ProductName", ProductName);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            IsFound = true;
                            ProductID = (int)reader["ProductID"];
                            Description = (string)reader["Description"];
                            LongDescription = (string)reader["LongDescription"];
                            Price = (decimal)reader["Price"];
                            QuantityInStock = (int)reader["QuantityInStock"];
                            CategoryID = (int)reader["CategoryID"];
                            SubCategoryID = (int)reader["SubCategoryID"];
                            if (reader["ImageURL"] == DBNull.Value)
                                ImageURL = "";
                            else
                                ImageURL = (string)reader["ImageURL"];
                            if (reader["VideoURL"] == DBNull.Value)
                                VideoURL = "";
                            else
                                VideoURL = (string)reader["VideoURL"];
                            if (reader["Discount"] == DBNull.Value)
                                Discount = 0;
                            else
                                Discount = (int)reader["Discount"];
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
        public static DataTable GetProductsPerPageForCategoryID(int PageNumber,int CategoryID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductPerPageForCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", PageNumber);
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
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

        public static DataTable GetProductsForCategoryID(int CategoryID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductsForCategoryID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
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

        public static DataTable GetProductsForSubCategoryID(int SubCategoryID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductsForSubCategoryID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
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
        public static DataTable GetAllProducts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllProducts", connection))
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
        public static DataTable GetMostSoldProducts(DateTime From,DateTime To)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetMostSoldProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@From", From);
                    command.Parameters.AddWithValue("@To", To);
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
        public static int GetTotalPages()
        {
            int TotalPages = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTotalPage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        object result=command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int totalPages))
                        {
                            TotalPages = totalPages;
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

            return TotalPages;
        }
        public static int GetTotalPagesForSubCategoryID(int SubCategoryID)
        {
            int TotalPages = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTotalPageForSubCategoryID", connection))
                {
                    command.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int totalPages))
                        {
                            TotalPages = totalPages;
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

            return TotalPages;
        }

        public static int GetTotalPagesForCategoryID(int CategoryID)
        {
            int TotalPages = 0;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetTotalPageForCategoryID", connection))
                {
                    command.Parameters.AddWithValue("@CategoryID", CategoryID);
                    command.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int totalPages))
                        {
                            TotalPages = totalPages;
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

            return TotalPages;
        }
        public static DataTable GetProductsPerPage(int PageNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductPerPage", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", PageNumber);
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

        public static DataTable GetProductsPerPageForSubCategoryID(int PageNumber,int SubCategoryID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetProductPerPageForSubCategory", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", PageNumber);
                    command.Parameters.AddWithValue("@SubCategoryID", SubCategoryID);
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
        public static DataTable GetAllFavouritesForCustomerID(int CustomerID)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("SP_GetAllFavouritesForCustomerID", connection))
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
        public static bool DeleteProductCatalog(int ProductID)
        {

            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Online_Store"].ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_DeleteProductCatalog", connection))
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
     
    }
}
