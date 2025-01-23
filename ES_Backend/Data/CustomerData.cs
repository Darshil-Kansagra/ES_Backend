using ES_Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ES_Backend.Data
{
    public class CustomerData
    {
        private readonly string _connectionString;

        #region configuration
        public CustomerData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region SelectAll
        public IEnumerable<CustomerModel> SelectAll()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Customer_SelectAll";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        customers.Add(new CustomerModel
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            MobileNo = reader["MobileNo"].ToString(),
                            Address = reader["Address"].ToString(),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }
        #endregion

        #region SelectById
        public CustomerModel SelectById(int id)
        {
            CustomerModel model = new CustomerModel();
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Customer_SelectById";
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model = new CustomerModel
                        {
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            MobileNo = reader["MobileNo"].ToString(),
                            Address = reader["Address"].ToString(),
                            UserId = Convert.ToInt32(reader["UserId"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            UpdatedDate = Convert.ToDateTime(reader["UpdatedDate"])
                        };
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return model;
        }
        #endregion

        #region Insert
        public bool Insert(CustomerModel model)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Customer_Insert";
                    cmd.Parameters.AddWithValue("@FirstName",model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@MobileNo", model.MobileNo);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@UserId", model.UserId);
                    int row = cmd.ExecuteNonQuery();
                    return row > 0;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        #endregion

        #region Update
        public bool Update(CustomerModel model,int id)
        {
            try
            {
                using(SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Customer_Update";
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@FirstName", model.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", model.MobileNo);
                    cmd.Parameters.AddWithValue("@FirstName", model.Address);
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
                    cmd.CommandText = "PR_Customer_Delete";
                    cmd.Parameters.AddWithValue("@CustomerId", id);
                    int rows = cmd.ExecuteNonQuery();
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
