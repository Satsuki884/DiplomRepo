using Dapper;
using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Repositories
{
    internal class ImageRepository
    {

        public Image Retrieve(int imageId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var image = connection.Query<Image>("SELECT * FROM image WHERE @imageId", imageId).FirstOrDefault();
                return image;
            }
        }
    }
}
