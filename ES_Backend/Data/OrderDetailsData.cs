using ES_Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ES_Backend.Data
{
    public class OrderDetailsData
    {
        private readonly string _connectionString;

        #region configuration
        public OrderDetailsData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region SelectAll
        public IEnumerable<OrderDetailsModel> SelectAll()
        {
            List<OrderDetailsModel> orderDetails = new List<OrderDetailsModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_OrderDetails_SelectAll";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orderDetails.Add(new OrderDetailsModel
                        {
                            OrderDetailId = Convert.ToInt32(reader["OrderDetailsId"]),
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Amount = Convert.ToDouble(reader["Amount"]),
                            TotalAmount = Convert.ToInt32(reader["TotalAmount"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return orderDetails;
        }
        #endregion

        #region Insert
        public bool Insert(OrderDetailsModel orderDetails)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_OrderDetails_Insert";
                    cmd.Parameters.AddWithValue("@ProductId", orderDetails.ProductId);
                    cmd.Parameters.AddWithValue("@OrderId", orderDetails.OrderId);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetails.Quantity);
                    cmd.Parameters.AddWithValue("@Amount", orderDetails.Amount);
                    cmd.Parameters.AddWithValue("@TotalAmount", orderDetails.TotalAmount);
                    cmd.Parameters.AddWithValue("@UserId", orderDetails.UserId);
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
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_OrderDetails_Delete";
                    cmd.Parameters.AddWithValue("@OrderDetailsId", id);
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
    }
}
