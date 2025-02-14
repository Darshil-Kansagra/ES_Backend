using ES_Backend.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ES_Backend.Data
{
    public class SpecificationData
    {
        private readonly string _connectionString;

        #region configuration
        public SpecificationData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connectionString");
        }
        #endregion

        #region GetAllTVSpec
        public SpecificationModel GetAllTVSpec(int id)
        {
            SpecificationModel model = new SpecificationModel();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Specification_SelectByProductId";
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model = new SpecificationModel
                        {
                            SpecificationId = Convert.ToInt32(reader["SpecificationId"]),
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            Brand = reader["Brand"].ToString(),
                            Sizes = Convert.ToInt32(reader["Sizes"]),
                            Resolution = reader["Resolution"].ToString(),
                            HDTechnology = reader["HDTechnology"].ToString(),
                            RefreshRate = Convert.ToInt32(reader["RefreshRate"]),
                            SoundTechnology = reader["SoundTechnology"].ToString(),
                            BrochureUrl = reader["BrochureUrl"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
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

        #region GetAllACSpec
        public SpecificationModel GetAllACSpec(int id)
        {
            SpecificationModel model = new SpecificationModel();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Specification_SelectByProductId";
                    cmd.Parameters.AddWithValue("@ProductId", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        model = new SpecificationModel
                        {
                            SpecificationId = Convert.ToInt32(reader["SpecificationId"]),
                            ProductId = Convert.ToInt32(reader["ProductId"]),
                            ModelNumber = reader["ModelNumber"].ToString(),
                            Brand = reader["Brand"].ToString(),
                            Capacity = Convert.ToInt32(reader["Capacity"]),
                            Refrigerant = reader["Refrigerant"].ToString(),
                            Voltage = Convert.ToInt32(reader["Voltage"]),
                            Color = reader["Color"].ToString(),
                            Warranty = Convert.ToInt32(reader["Warranty"]),
                            StarRating = Convert.ToInt32(reader["StarRating"]),
                            BrochureUrl = reader["BrochureUrl"].ToString(),
                            CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
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

        #region InsertTV
        public bool InsertTV(SpecificationModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Specification_Insert_TV";
                    cmd.Parameters.AddWithValue("@ModelNumber", model.ModelNumber);
                    cmd.Parameters.AddWithValue("@Brand", model.Brand);
                    cmd.Parameters.AddWithValue("@Sizes", model.Sizes);
                    cmd.Parameters.AddWithValue("@Resolution", model.Resolution);
                    cmd.Parameters.AddWithValue("@HDTechnology", model.HDTechnology);
                    cmd.Parameters.AddWithValue("@RefreshRate", model.RefreshRate);
                    cmd.Parameters.AddWithValue("@SoundTechnology", model.SoundTechnology);
                    cmd.Parameters.AddWithValue("@Warranty", model.Warranty);
                    cmd.Parameters.AddWithValue("@StarRating", model.StarRating);
                    cmd.Parameters.AddWithValue("@BrochureUrl", model.BrochureUrl);
                    cmd.Parameters.AddWithValue("@ProductId",model.ProductId);
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

        #region InsertAC
        public bool InsertAC(SpecificationModel model)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "PR_Specification_Insert_AC";
                    cmd.Parameters.AddWithValue("@ModelNumber", model.ModelNumber);
                    cmd.Parameters.AddWithValue("@Brand", model.Brand);
                    cmd.Parameters.AddWithValue("@Capacity", model.Capacity);
                    cmd.Parameters.AddWithValue("@Refrigerant", model.Refrigerant);
                    cmd.Parameters.AddWithValue("@Voltage", model.Voltage);
                    cmd.Parameters.AddWithValue("@Color", model.Color);
                    cmd.Parameters.AddWithValue("@Warranty", model.Warranty);
                    cmd.Parameters.AddWithValue("@StarRating", model.StarRating);
                    cmd.Parameters.AddWithValue("@BrochureUrl", model.BrochureUrl);
                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
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
    }
}
