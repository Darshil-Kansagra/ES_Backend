using ES_Backend.Models;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ES_Backend.Data
{
    public class ProductData
    {
        private readonly string _connectionString;

        #region configuration
        public ProductData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region SelectAll
        public IEnumerable<ProductModel> SelectAll()
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Product_SelectAll";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new ProductModel
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                            ProductType = reader["ProductType"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : (DateTime?)null,
                            UpdatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return products;
        }
        #endregion

        #region SelectById
        public ProductModel SelectById(int id)
        {
            ProductModel model = new ProductModel();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Product_SelectById";
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model = new ProductModel
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                            ProductType = reader["ProductType"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : (DateTime?)null,
                            UpdatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return model;
        }
        #endregion

        #region Insert
        public bool Insert(ProductModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Product_Insert";
                    cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@ProductType", model.ProductType);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);
                    cmd.Parameters.AddWithValue("@StockQuantity", model.StockQuantity);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        #endregion

        #region Update
        public bool Update(ProductModel model,int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Product_Update";
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                    cmd.Parameters.AddWithValue("@Description", model.Description);
                    cmd.Parameters.AddWithValue("@Price", model.Price);
                    cmd.Parameters.AddWithValue("@ProductType", model.ProductType);
                    cmd.Parameters.AddWithValue("@ImageUrl", model.ImageUrl);
                    cmd.Parameters.AddWithValue("@StockQuantity", model.StockQuantity);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Product_Delete";
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        #endregion

        #region SearchProduct
        public IEnumerable<ProductModel> SearchProduct(SearchModel model)
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Product_Search";
                    cmd.Parameters.AddWithValue("@Keyword", model.Keyword);
                    cmd.Parameters.AddWithValue("@ProductType", model.ProductType);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new ProductModel
                        {
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ProductName = reader["ProductName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                            ProductType = reader["ProductType"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString(),
                            StockQuantity = Convert.ToInt32(reader["StockQuantity"]),
                            CreatedDate = reader["CreatedDate"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedDate"]) : (DateTime?)null,
                            UpdatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return products;
        }
        #endregion
    }
}
