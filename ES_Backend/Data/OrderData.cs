using ES_Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ES_Backend.Data
{
    public class OrderData
    {
        private readonly string _connectionString;

        #region configuration
        public OrderData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region SelectAll
        public IEnumerable<OrderModel> SelectAll()
        {
            List<OrderModel> orders = new List<OrderModel>();
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Order_SelectAll";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Add(new OrderModel
                        {
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            Price = Convert.ToInt32(reader["Price"]),
                            ShippingAddress = reader["ShippingAddress"].ToString(),
                            PaymentMode = reader["OrderId"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return orders;
        }
        #endregion

        #region SelectByUserId
        public IEnumerable<OrderModel> SelectByUserId(int id)
        {
            List<OrderModel> orders = new List<OrderModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Order_SelectByUserId";
                    cmd.Parameters.AddWithValue("@UserId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orders.Add(new OrderModel
                        {
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            Price = Convert.ToInt32(reader["Price"]),
                            ShippingAddress = reader["ShippingAddress"].ToString(),
                            PaymentMode = reader["OrderId"].ToString(),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            UserId = Convert.ToInt32(reader["UserId"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return orders;
        }
        #endregion

        #region Insert
        public bool Insert(OrderModel order)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Order_Insert";
                    cmd.Parameters.AddWithValue("@Price", order.Price);
                    cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                    cmd.Parameters.AddWithValue("@PaymentMode", order.PaymentMode);
                    cmd.Parameters.AddWithValue("@UserId", order.UserId);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        #endregion

        #region Delete
        public bool Delete(int id)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Order_Delete";
                    cmd.Parameters.AddWithValue("@OrderId",id);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        #endregion
    }
}
