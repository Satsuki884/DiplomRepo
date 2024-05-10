using Dapper;
using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Repositories
{
    internal class StoneLevelRepository
    {

        public StoneLevel Retrieve(int LevelId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var stoneLevel = connection.Query<StoneLevel>("SELECT * FROM stonelevel WHERE @LevelId", LevelId).FirstOrDefault();
                return stoneLevel;
            }
        }
        public bool Update(StoneLevel stoneLevel)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                bool result = false;
                var rowsAffected = connection.Execute(@"UPDATE Match
                                                    SET StoneLevelId = @StoneLevelId,
                                                        LevelId = @LevelId,
                                                        StoneId = @StoneId"
                    , stoneLevel);
                result = rowsAffected == 1;
                return result;
            }
        }
    }
}
