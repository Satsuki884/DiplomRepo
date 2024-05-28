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
    public class AnswerRepository
    {

        public List<Answer> Retrieve()
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var answers = connection.Query<Answer>("SELECT * FROM answer").AsList();
                return answers;
            }
        }

        public Answer Retrieve(string value)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var answer = connection.Query<Answer>("SELECT * FROM answer WHERE value = @value", value).FirstOrDefault();
                return answer;
            }
        }

        public Answer Retrieve(int AnswerId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var answer = connection.Query<Answer>("SELECT * FROM answer WHERE AnswerId = @AnswerId", AnswerId).FirstOrDefault();
                return answer;
            }
        }


    }
}
