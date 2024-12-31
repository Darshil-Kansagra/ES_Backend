using ES_Backend.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace ES_Backend.Data
{
    public class UserData
    {
        private readonly string _connectionString;

        #region configuration
        public UserData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region SelectAll
        public IEnumerable<UserModel> SelectAll()
        {
            List<UserModel> model = new List<UserModel>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_User_SelectAll";
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        model.Add(new UserModel
                        {
                            UserId = Convert.ToInt32(reader["UserId"]),
                            UserName = reader["UserName"].ToString(),
                            Password = reader["Password"].ToString(),
                            Role = reader["Role"].ToString(),
                            IsActive = Convert.ToBoolean(reader["IsActive"]),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                            UpdatedDate = Convert.ToDateTime(reader["Updateddate"])
                        });
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return model;
        }
        #endregion

        #region Insert
        [HttpPost]
        public bool Insert(UserModel user)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_User_Insert";
                    cmd.Parameters.AddWithValue("@UserName", user.UserName);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.Parameters.AddWithValue("@IsActive", user.IsActive);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
        #endregion
    }
}
