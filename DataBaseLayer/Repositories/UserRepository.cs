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
                var user = connection.Query<User>("SELECT * FROM user WHERE UserId = @UserId", new { UserId }).FirstOrDefault();
                return user;
            }
        }

        public User Retrieve(string name)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var user = connection.Query<User>("SELECT * FROM user WHERE name = @name", new { name }).FirstOrDefault();
                return user;
            }
        }

        public bool Update(User user)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                bool result = false;
                var rowsAffected = connection.Execute(@"UPDATE user
                                                    SET UserId = @UserId,
                                                imageId = @ImageId,
                                                name = @Name,
                                                sex = @Sex,
                                                isSword = @IsSword,
                                                isBoots = @IsBoots,
                                                isFlashlight = @IsFlashlight, 
                                                isArmor = @IsArmor,
                                                isAmulet = @IsAmulet,
                                                isAura = @IsAura
                                            WHERE UserId = @UserId",
                    new
                    {
                        user.UserId,
                        user.ImageId,
                        user.Name,
                        user.Sex,
                        user.IsSword,
                        user.IsBoots,
                        user.IsFlashlight,
                        user.IsArmor,
                        user.IsAmulet,
                        user.IsAura
                    });
                result = rowsAffected == 1;
                return result;
            }
        }
    }
}
