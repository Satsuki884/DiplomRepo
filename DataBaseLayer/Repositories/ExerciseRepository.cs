using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
using Dapper;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Repositories
{
    public class ExerciseRepository
    {
        public List<Exercise> Retrieve()
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var stones = connection.Query<Exercise>("SELECT * FROM exercise").AsList();
                return stones;
            }
        }

        public Exercise Retrieve(int ExerciseId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var exercise = connection.Query<Exercise>("SELECT * FROM exercise WHERE @ExerciseId", ExerciseId).FirstOrDefault();
                return exercise;
            }
        }     
    }
}
