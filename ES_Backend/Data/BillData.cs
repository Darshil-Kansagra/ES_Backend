using ES_Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ES_Backend.Data
{
    public class BillData
    {
        private readonly string _connectionString;

        #region configuration
        public BillData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region SelectAll
        public IEnumerable<BillModel> SelectAll(int id)
        {
            List<BillModel> bills = new List<BillModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Bill_SelectAll";
                    cmd.Parameters.AddWithValue("@OrderId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        bills.Add(new BillModel
                        {
                            BillId = Convert.ToInt32(reader["BillId"]),
                            BillNumber = Convert.ToInt32(reader["BillNumber"]),
                            BillDate = Convert.ToDateTime(reader["BillDate"]),
                            Amount = Convert.ToDouble(reader["Amount"]),
                            Discount = Convert.ToDouble(reader["Discount"]),
                            TotalAmount = Convert.ToDouble(reader["TotalAmount"]),
                            OrderId = Convert.ToInt32(reader["OrderId"]),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            UserName = reader["UserName"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bills;
        }
        #endregion

        #region Insert
        public bool Insert(BillModel model)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Bill_Insert";
                    cmd.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd.Parameters.AddWithValue("@Discount", model.Discount);
                    cmd.Parameters.AddWithValue("@TotalAmount", model.TotalAmount);
                    cmd.Parameters.AddWithValue("@OrderId", model.OrderId);
                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
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
                    cmd.CommandText = "PR_Bill_Delete";
                    cmd.Parameters.AddWithValue("@BillId", id);
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
