using FlickClick_ClassLibary.DataAccess;
using FlickClick_ClassLibary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickClick_ClassLibary.BusinessLogic
{
    public class MovieProcess
    {
        public static List<MovieCommentCountModel> LoadMovie()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                INNER JOIN comments ON comments.Movie_ID = movies.ID 
                                GROUP BY movies.ID ORDER BY Created DESC;";

            return SqlDataAccess.LoadData<MovieCommentCountModel>(sql);
        }

        public static List<MovieModel> LoadMovieMostComments()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                INNER JOIN comments ON comments.Movie_ID = movies.ID 
                                GROUP BY movies.ID ORDER BY CommentCount DESC;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadSingleMovie(Nullable<int> id)
        {
            string sql = $"SELECT * FROM news WHERE ID = {id}";

            if (id == null)
            {
                sql = $"SELECT * FROM news WHERE ID = 0";
            }
            else
            {
                sql = $"SELECT * FROM news WHERE ID = {id}";
            }


            return SqlDataAccess.LoadData<MovieModel>(sql);
        }
    }
}
