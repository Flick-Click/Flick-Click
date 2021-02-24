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
        public static int CreateComment(string content, int movie_ID, int user_ID)
        {
            CommentModel data = new CommentModel
            {
                Content = content,
                Movie_ID = movie_ID,
                User_ID = user_ID
            };

            string sql = @"INSERT INTO comments (Content, Movie_ID, User_ID) VALUES (@Content, @Movie_ID, @User_ID)";

            return SqlDataAccess.SaveData<CommentModel>(sql, data);
        }

        public static List<CommentModel> LoadComments(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT comments.ID, Content, comments.Created, Movie_ID, CONCAT(users.FirstName, ' ', users.LastName) AS Name, User_ID FROM comments LEFT JOIN users ON comments.User_ID = users.ID WHERE Movie_ID = 0 ORDER BY comments.Created DESC;";

            }
            else
            {
                sql = $"SELECT comments.ID, Content, comments.Created, Movie_ID, CONCAT(users.FirstName, ' ', users.LastName) AS Name, User_ID FROM comments LEFT JOIN users ON comments.User_ID = users.ID WHERE Movie_ID = {id} ORDER BY comments.Created DESC;";
            }

            return SqlDataAccess.LoadData<CommentModel>(sql);
        }

        public static List<CommentModel> LoadAllComments()
        {


            string sql = $"SELECT comments.ID, Content, comments.Created, Movie_ID, " +
                $"CONCAT(users.FirstName, ' ', users.LastName) " +
                $"AS Name, User_ID " +
                $"FROM comments " +
                $"LEFT JOIN users ON comments.User_ID = users.ID ORDER BY comments.Created DESC;";

            return SqlDataAccess.LoadData<CommentModel>(sql);
        }

        public static List<CommentModel> LoadComment(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT comments.ID, Content, Movie_ID FROM comments WHERE ID = 0;";

            }
            else
            {
                sql = $"SELECT comments.ID, Content, Movie_ID FROM comments WHERE ID = {id}";
            }

            return SqlDataAccess.LoadData<CommentModel>(sql);
        }


        public static int UpdateComment(int id, string content)
        {
            CommentModel data = new CommentModel
            {
                ID = id,
                Content = content
            };

            string sql = @"UPDATE comments SET Content = @Content WHERE ID = @ID;";

            return SqlDataAccess.SaveData<CommentModel>(sql, data);
        }

        public static int DeleteComment(Nullable<int> id)
        {
            string sql = $"DELETE FROM comments WHERE ID = {id}";

            return SqlDataAccess.DeleteData(sql);
        }
    }
}
