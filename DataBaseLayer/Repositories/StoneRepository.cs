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
    internal class StoneRepository
    {
        public List<Stone> Retrieve()
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var stones = connection.Query<Stone>("SELECT * FROM stone").AsList();
                return stones;
            }
        }

        public Stone Retrieve(int StoneId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var stone = connection.Query<Stone>("SELECT * FROM stone WHERE @StoneId", StoneId).FirstOrDefault();
                return stone;
            }
        }

        public Stone Retrieve(StoneValue stoneValue)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var stone = connection.Query<Stone>("SELECT * FROM Stone WHERE @stoneValue", stoneValue).FirstOrDefault();
                return stone;
            }
        }

        
    }
}
