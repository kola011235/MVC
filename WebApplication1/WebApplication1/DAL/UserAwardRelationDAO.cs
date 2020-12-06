using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task_3_DB.Entities;

namespace task_3_DB.DAL
{
    class UserAwardRelationDAO : IUserAwardRelationDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=awards_and_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void AwardUsers(int awardID, List<int> winnersID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("AwardUsers", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                foreach (int item in winnersID)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("AwardID", awardID);
                    cmd.Parameters.AddWithValue("UserID", item);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public ICollection<Award> GetAwardsOfUserByID(int ID)
        {
            ICollection<Award> result = new List<Award>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("GetAwardsOfUserByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.AddWithValue("ID", ID);
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
    }
}
