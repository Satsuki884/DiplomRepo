using Dapper;
using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Repositories
{
    public class LevelRepository
    {
        public List<Level> Retrieve()
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var levels = connection.Query<Level>("SELECT * FROM level").AsList();
                return levels;
            }
        }

        public Level Retrieve(int LevelId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var level = connection.Query<Level>("SELECT * FROM level WHERE LevelId = @LevelId",new { LevelId }).FirstOrDefault();
                return level;
            }
        }
          
        public Level Retrieve(string name) 
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var level = connection.Query<Level>("SELECT * FROM level WHERE name = @name", new { name }).FirstOrDefault();
                return level;
            }
        }

        public bool Update(Level level)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                bool result = false;
                var rowsAffected = connection.Execute(@"UPDATE level
                                                    SET LevelId = @LevelId,
                                                name = @name,
                                                max_rate = @max_rate,
                                                grade = @grade,
                                                isBoss = @isBoss,
                                                isCompleted = @isCompleted, 
                                                isAvailable = @isAvailable,
                                                stoneId = @stoneId
                                            WHERE LevelId = @LevelId",
                    new
                    {
                        level.LevelId,
                        level.Name,
                        level.Max_rate,
                        level.Grade,
                        level.IsBoss,
                        level.IsCompleted,
                        level.IsAvailable,
                        level.StoneId
                    });
                result = rowsAffected == 1;
                return result;
            }
        }

    }
}
