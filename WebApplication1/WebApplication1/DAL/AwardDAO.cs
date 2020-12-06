using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using task_3_DB.Entities;

namespace task_3_DB.DAL
{
    class AwardDAO : IAwardDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=awards_and_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ICollection<Award> GetAllAwards()
        {
            ICollection<Award> result = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("GetAllAwards", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var award = new Award()
                    {
                        ID = (int)reader["ID"],
                        Title = (string)reader["Title"],
                    };
                    result.Add(award);
                }
            }
            return result;
        }
        public Award GetAwardByID(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("GetAwardByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = ID;
                connection.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var award = new Award()
                {
                    ID = (int)reader["ID"],
                    Title = (string)reader["Title"],
                };
                return award;
            }
        }
        public void DeleteAwardByID(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("DeleteAwardByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = ID;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public int AddAward(Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("AddAward", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter output = new SqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.AddWithValue("Title", award.Title);
                cmd.Parameters.Add(output);
                connection.Open();
                cmd.ExecuteNonQuery();
                return int.Parse(output.Value.ToString());
            }
        }
        public void UpdateAward(Award award)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("UpdateAward", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Title", award.Title);
                cmd.Parameters.AddWithValue("ID", award.ID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
