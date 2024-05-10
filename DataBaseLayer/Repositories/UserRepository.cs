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
    internal class UserRepository
    {

        public User Retrieve(int UserId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM user WHERE @UserId", UserId).FirstOrDefault();
                return user;
            }
        }

        public User Retrieve(string name)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM user WHERE @name", name).FirstOrDefault();
                return user;
            }
        }
    }
}
