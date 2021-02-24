using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class NewsProcess
    {
        public static int CreateNews(string title, string content)
        {
            NewsModel data = new NewsModel
            {
                Title = title,
                Content = content
            };

            string sql = @"INSERT INTO news (Title, Content) VALUES (@Title, @Content);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<NewsModel> LoadNews()
        {
            string sql = @"SELECT * FROM news ORDER BY Created DESC;";

            return SqlDataAccess.LoadData<NewsModel>(sql);
        }

        public static List<NewsModel> LoadNyNews()
        {
            string sql = @"SELECT ID, Title, Content, Created FROM news ORDER BY Created DESC;";

            return SqlDataAccess.LoadData<NewsModel>(sql);
        }

        public static List<NewsModel> LoadSingleNews(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT ID, Title, Content, Created FROM news WHERE ID = 0";
            }
            else
            {
                sql = $"SELECT ID, Title, Content, Created FROM news WHERE ID = {id}";
            }


            return SqlDataAccess.LoadData<NewsModel>(sql);
        }

        public static int UpdateNews(int id, string title, string content)
        {
            NewsModel data = new NewsModel
            {
                ID = id,
                Title = title,
                Content = content
            };

            string sql = @"UPDATE news SET Title = @Title, Content = @Content WHERE ID = @ID;";

            return SqlDataAccess.SaveData<NewsModel>(sql, data);
        }

        // ID is giving from frontend model.ID
        public static int Deletenews(Nullable<int> id)
        {
            string sql = $"DELETE FROM news WHERE ID = {id};";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
