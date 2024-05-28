using Dapper;
using DataBaseLayer.DBSettings;
using MySql.Data.MySqlClient;
using static DataBaseLayer.Models.Models;

namespace DataBaseLayer.Repositories
{
    public class ImageRepository
    {

        public List<Image> Retrieve() 
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var images = connection.Query<Image>("SELECT * FROM image").AsList();
                return images;
            }
        }


        public Image Retrieve(int imageId)
        {
            using (var connection = new MySqlConnection(DataBaseManager.ConnectionString))
            {
                connection.Open();
                var image = connection.Query<Image>("SELECT * FROM image WHERE imageId = @imageId", new { imageId }).FirstOrDefault();
                return image;
            }
        }
    }
}
