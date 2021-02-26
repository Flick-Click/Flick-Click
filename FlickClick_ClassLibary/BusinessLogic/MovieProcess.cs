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

            sql += @"SELECT last_insert_id()";
            return Convert.ToInt32(SqlDataAccess.SaveDataThatReturnsId(sql, data));
            
        }

        public static int CreateMovieGenre(int MovieID, string[] genres)
        {
            
            foreach (var genre in genres)
            {

                GenreModel data = new GenreModel
                {
                    MovieID = MovieID,
                    GenreID = Convert.ToInt32(genre)
               };
                string sql = @"INSERT INTO movie_genres (MovieID,GenreID) VALUES (@MovieID, @GenreID)";
                SqlDataAccess.SaveData(sql,data);
            }
            return 1;
        }
        public static int CreateMovieWriter(int MovieID, string[] writers)
        {

            foreach (var writer in writers)
            {

                WritersModel data = new WritersModel
                {
                    MovieID = MovieID,
                    ID = Convert.ToInt32(writer)
                };
                string sql = @"INSERT INTO movie_writers (movieID, PeopleID) VALUES (@movieID, @ID)";
                SqlDataAccess.SaveData(sql, data);
            }
            return 1;
        }
        public static int CreateMovieDirector(int MovieID, string[] directors)
        {

            foreach (var director in directors)
            {

                DirectorsModel data = new DirectorsModel
                {
                    MovieID = MovieID,
                    ID = Convert.ToInt32(director)
                };
                string sql = @"INSERT INTO movie_directors (movieID, PeopleID) VALUES (@movieID, @ID)";
                SqlDataAccess.SaveData(sql, data);
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
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.MovieID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                LEFT JOIN comments ON comments.MovieID = movies.ID 
                                GROUP BY movies.ID;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadComingSoonMovies()
        {
            string sql = @"SELECT ID, Title, Description, Picture_Path, `Release`
                           FROM movies 
                           ORDER BY `Release` DESC;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadLatestMovies()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.MovieID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                LEFT JOIN comments ON comments.MovieID = movies.ID 
                                GROUP BY movies.ID ORDER BY Created DESC;";

            return SqlDataAccess.LoadData<MovieModel>(sql);
        }

        public static List<MovieModel> LoadMovieMostComments()
        {
            string sql = @"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.MovieID) AS CommentCount FROM movies 
                                INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID
                                LEFT JOIN comments ON comments.MovieID = movies.ID 
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
                sql = $"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.MovieID) AS CommentCount FROM movies INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID INNER JOIN comments ON comments.MovieID = movies.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT movies.ID, Title, Description, Duration, Rating, Picture_Path, Trailer, movies.`Release`, movies.Created, agerestrictions.AgeRestriction, COUNT(comments.MovieID) AS CommentCount FROM movies INNER JOIN agerestrictions ON movies.Age_Rating = agerestrictions.ID INNER JOIN comments ON comments.MovieID = movies.ID WHERE movies.ID = {id}";
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
                sql = $"SELECT Genre FROM movie_genres INNER JOIN movies ON movie_genres.MovieID = movies.ID INNER JOIN genres ON movie_genres.GenreID = genres.ID WHERE movies.ID = 0";

            }
            else
            {
                sql = $"SELECT Genre FROM movie_genres INNER JOIN movies ON movie_genres.MovieID = movies.ID INNER JOIN genres ON movie_genres.GenreID = genres.ID WHERE movies.ID = {id}";
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
