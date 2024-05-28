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
    internal class ExAnswerRepository
    {

        public List<ExAnswer> RetrieveByImageId(int ExerciseId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var exAnswers = connection.Query<ExAnswer>("SELECT * FROM exanswers WHERE ExerciseId = @ExerciseId", ExerciseId).AsList();
                return exAnswers;

            }
        }
    }
}
