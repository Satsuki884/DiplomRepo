using Dapper;
using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
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
                var level = connection.Query<Level>("SELECT * FROM level WHERE @LevelId", LevelId).FirstOrDefault();
                return level;
            }
        }

        public Level Retrieve(string name)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var level = connection.Query<Level>("SELECT * FROM level WHERE @name", name).FirstOrDefault();
                return level;
            }
        }

        public bool Update(Level level)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                bool result = false;
                var rowsAffected = connection.Execute(@"UPDATE Match
                                                    SET LevelId = @LevelId,
                                                        imageId = @imageId,
                                                        name = @name,
                                                        max_rate = @max_rate,
                                                        grade = @grade,
                                                        isBoss = @isBoss,
                                                        isCompleted = @isCompleted, 
                                                        isAvailable = @isAvailable"
                    , level);
                result = rowsAffected == 1;
                return result;
            }
        }

    }
}
