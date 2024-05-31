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
    public class ExImageRepository
    {

        public List<ExImage> RetrieveByImageId(int ExerciseId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var exImages = connection.Query<ExImage>("SELECT * FROM eximages WHERE ExerciseId = @ExerciseId", new { ExerciseId }).AsList();
                return exImages;

            }
        }


    }
}
