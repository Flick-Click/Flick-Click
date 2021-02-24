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
        public static int Createmovie(string title, string description, int duration, string pictureName, string trailer, DateTime release, int rating, int age_rating)
        {
            MovieModel data = new MovieModel
            {
                Title = title,
                Description = description,
                Duration = duration,
                Picture_Path = pictureName,
                Trailer = trailer,
                Release = release,
                Rating = rating,
                Age_Rating = age_rating
            };

            string sql = @"INSERT INTO movies (Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, Age_Rating) VALUES (@Title, @Description, @Duration, @Rating, @Picture_Path, @Trailer, @Release, @Age_Rating);";
            return SqlDataAccess.SaveData(sql, data);
        }

        public static int CreateGenre(int MovieID, List<GenreModel> genres)
        {
            foreach (var genre in genres)
            {
            }
            return 1;
        }

        public static int Deletemovie(Nullable<int> id)
        {
            string sql = $"DELETE FROM movies WHERE ID = {id};";
            return SqlDataAccess.DeleteData(sql);
        }

        public static List<MovieModel> LoadMovies()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                LEFT JOIN comments ON comments.Movie_ID = movies.ID 
                                GROUP BY movies.ID;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadLatestMovies()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                LEFT JOIN comments ON comments.Movie_ID = movies.ID 
                                GROUP BY movies.ID ORDER BY Created DESC;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadMovieMostComments()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                LEFT JOIN comments ON comments.Movie_ID = movies.ID 
                                GROUP BY movies.ID ORDER BY CommentCount DESC;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadSingleMovie(Nullable<int> id)
        {
            string sql;

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

        public static List<MovieModel> LoadSearchedMovies(string GSearch)
        {
            string sql = $"SELECT Title, Picture_Path FROM movie WHERE title LIKE %{GSearch}%;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadMovieDetails(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID INNER JOIN comments ON comments.Movie_ID = movies.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.Movie_ID) AS CommentCount FROM movies INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID INNER JOIN comments ON comments.Movie_ID = movies.ID WHERE movies.ID = {id}";
            }

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }
        public static List<AgeRatingModel> LoadAgeRating()
        {
            string sql = @"SELECT * FROM agerestrictions";

            return SqlDataAccess.LoadData<AgeRatingModel>(sql);
        }
        public static List<AgeRatingModel> LoadAgeRating(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT agerestrictions.AgeRestriction FROM movies INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT agerestrictions.AgeRestriction FROM movies INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID WHERE movies.ID = {id}";
            }

            return SqlDataAccess.LoadData<AgeRatingModel>(sql);
        }

        public static List<GenreModel> LoadGenre(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT Genre FROM movie_genres INNER JOIN movies ON movie_genres.Movie_ID = movies.ID INNER JOIN genres ON movie_genres.Genre_ID = genres.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT Genre FROM movie_genres INNER JOIN movies ON movie_genres.Movie_ID = movies.ID INNER JOIN genres ON movie_genres.Genre_ID = genres.ID WHERE movies.ID = {id}";
            }

            return SqlDataAccess.LoadData<GenreModel>(sql);
        }


        public static List<DirectorsModel> LoadDirector(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $" SELECT FirstName, LastName FROM movie_directors INNER JOIN movies ON movie_directors.movieID = movies.ID INNER JOIN people ON movie_directors.PeopleID = people.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT FirstName, LastName FROM movie_directors INNER JOIN movies ON movie_directors.movieID = movies.ID INNER JOIN people ON movie_directors.PeopleID = people.ID WHERE movies.ID = {id}";
            }

            return SqlDataAccess.LoadData<DirectorsModel>(sql);
        }

        public static List<WritersModel> LoadWriters(Nullable<int> id)
        {
            string sql;

            if (id == null)
            {
                sql = $"SELECT FirstName, LastName FROM movie_writers INNER JOIN movies ON movie_writers.movieID = movies.ID INNER JOIN people ON movie_writers.PeopleID = people.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT FirstName, LastName FROM movie_writers INNER JOIN movies ON movie_writers.movieID = movies.ID INNER JOIN people ON movie_writers.PeopleID = people.ID WHERE movies.ID = {id}";
            }

            return SqlDataAccess.LoadData<WritersModel>(sql);
        }
    }
}
