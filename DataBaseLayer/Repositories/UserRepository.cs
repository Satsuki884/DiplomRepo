using Dapper;
using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Repositories
{
    public class UserRepository
    {

        public List<User> Retrieve()
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var users = connection.Query<User>("SELECT * FROM user").AsList();
                return users;
            }
        }

        public User Retrieve(int UserId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM user WHERE UserId = @UserId", UserId).FirstOrDefault();
                return user;
            }
        }

        public User Retrieve(string name)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM user WHERE name = @name", name).FirstOrDefault();
                return user;
            }
        }
    }
}
