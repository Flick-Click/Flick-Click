using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class CommentProcess
    {
        public int CreateComment(string content, int movie_ID, int user_ID)
        {
            CommentModel data = new CommentModel
            {
                Content = content,
                Movie_ID = movie_ID,
                User_ID = user_ID
            };

            string sql = @"INSERT INTO comments (Content, Movie_ID, User_ID) VALUES (@Content, @Movie_ID, User_ID)";

            return SqlDataAccess.SaveData<CommentModel>(sql, data);
        }

        public List<CommentModel> LoadComments(int id)
        {
            string sql = @"SELECT comments.ID, Content, comments.Created, CONCAT(users.FirstName, ' ', users.LastName) AS Name FROM comments LEFT JOIN users ON comments.User_ID = users.ID WHERE Movie_ID = @1 ORDER BY comments.Created DESC;";

            return SqlDataAccess.LoadData<CommentModel>(sql);
        }

        public int DeleteComment(int id)
        {
            string sql = @"DELETE FROM comments WHERE ID = @ID";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
