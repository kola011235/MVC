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
    class UserDAO : IUserDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=awards_and_users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public ICollection<User> GetAllUsers()
        {
            ICollection<User> result = new List<User>();
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("GetAllUsers", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var user = new User()
                    {

                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        DateIfBirth = (DateTime)reader["DateIfBirth"]
                    };
                    result.Add(user);
                }
            }
            return result;
        }
        public User GetUserdByID(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("GetUserByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = ID;
                connection.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var user = new User()
                {

                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Age = (int)reader["Age"],
                    DateIfBirth = (DateTime)reader["DateIfBirth"]
                };
                return user;
            }
        }
        public void AddUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("AddUser", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("Age", user.Age);
                cmd.Parameters.AddWithValue("DateIfBirth", user.DateIfBirth);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(User user)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("UpdateUser", connection);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", user.ID);
                cmd.Parameters.AddWithValue("Name", user.Name);
                cmd.Parameters.AddWithValue("Age", user.Age);
                cmd.Parameters.AddWithValue("DateIfBirth", user.DateIfBirth);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteUserByID(int ID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand("DeleteUserByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = ID;
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
