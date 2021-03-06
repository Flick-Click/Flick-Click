﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.MovieProcess;
using static FlickClick_ClassLibary.BusinessLogic.CommentProcess;
using static FlickClick_ClassLibary.BusinessLogic.PeopleProcess;
using static FlickClick_ClassLibary.BusinessLogic.GenreProcess;


using Flick_Click.Models;
using System.IO;

namespace Flick_Click.Controllers
{
    public class MovieController : Controller
    {
        // ----------------- Movie List Section ------------------

        // GET: MostCommentedMovie
        public ActionResult MostCommentedMovie()
        {
            var data = LoadMovieMostComments();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path,
                    CommentCount = movie.CommentCount
                });
            }

            return View(Movies);
        }

        // GET: LatestTrailer
        public ActionResult LatestMovies()
        {
            var data = LoadLatestMovies();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path,
                    CommentCount = movie.CommentCount
                });
            }

            return View(Movies);
        }

        public ActionResult ComingSoonMovies()
        {
            var data = LoadComingSoonMovies();
            List<MovieModel> Movies = new List<MovieModel>();

            if (data.Count >= 2)
            {
                for (int i = 0; i <= 1; i++)
                {
                    Movies.Add(new MovieModel
                    {
                        ID = data[i].ID,
                        Title = data[i].Title,
                        Release = data[i].Release,
                        Img = data[i].Picture_Path,
                        Description = data[i].Description
                    });
                }
            }
            else
            {
                for (int i = 0; i <= data.Count - 1; i++)
                {
                    Movies.Add(new MovieModel
                    {
                        ID = data[i].ID,
                        Title = data[i].Title,
                        Release = data[i].Release,
                        Img = data[i].Picture_Path,
                        Description = data[i].Description
                    });
                }
            }

            return PartialView(Movies);
        }

        // GET: ShowAll
        public ActionResult ShowAll()
        {
            var data = LoadMovies();
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    Img = movie.Picture_Path,
                    CommentCount = movie.CommentCount
                });
            }

            return View(Movies);
        }

        // ----------------- Create Section ------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(CommentModel model, int id)
        {
            if (Session["userID"] != null)
            {
                CreateComment(model.Comment, id, model.UserID);

                return RedirectToAction("MovieDetails", "Movie", new { id });
            }

            return RedirectToAction("MovieDetails", "Movie", new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePeople(DirectorModel model)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var data = LoadPeople();
                    bool Exists = false;

                    foreach (var Person in data)
                    {
                        if (Person.FirstName == model.FirstName && Person.LastName == model.LastName)
                        {
                            Exists = true;
                        }
                    }

                    if (!Exists)
                    {
                        Createpeople(model.FirstName, model.LastName);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateGenre(GenresModel model)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var data = Loadgenre();
                    bool Exists = false;

                    foreach (var genre in data)
                    {
                        if (genre.Genre == model.Genre)
                        {
                            Exists = true;
                        }
                    }

                    if (!Exists)
                    {
                        Creategenre(model.Genre);
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(CreateMovieModel model, FormCollection form)
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var data = LoadMovies();
                    bool Exists = false;

                    foreach (var Movie in data)
                    {
                        if (Movie.Title == model.Title)
                        {
                            Exists = true;
                        }
                    }

                    if (!Exists)
                    {
                        // Get file name
                        string fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                        // Get file extension like jpg, gif etc.
                        string extension = Path.GetExtension(model.ImageFile.FileName);
                        // Set date on file name so no duplicates.
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        // Set path
                        model.Img = "/Content/Pictures/" + fileName;
                        fileName = Path.Combine(Server.MapPath("/Content/Pictures/"), fileName);
                        // Save image
                        model.ImageFile.SaveAs(fileName);
                        int ageRating;
                        int.TryParse(form["Age_rating"], out ageRating);

                        string[] genres = form["Genre"].Split(',');
                        string[] writers = form["Writers"].Split(',');
                        string[] Directores = form["Directors"].Split(',');

                        int MovieID = Createmovie(model.Title, model.Description, model.Duration, model.Img, model.Trailer, model.Release, model.Rating, ageRating);
                        CreateMovieGenre(MovieID, genres);
                        CreateMovieWriter(MovieID, writers);
                        CreateMovieDirector(MovieID, Directores);
                    }

                    return RedirectToAction("index", "Administration");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // ----------------- Read Section ------------------

        // GET: Movie
        public ActionResult MovieDetails(Nullable<int> id)
        {
            var data = LoadMovieDetails(id);
            List<MovieModel> Movies = new List<MovieModel>();

            foreach (var movie in data)
            {
                Movies.Add(new MovieModel
                {
                    ID = movie.ID,
                    Title = movie.Title,
                    CommentCount = movie.CommentCount,
                    Duration = movie.Duration,
                    Release = movie.Release,
                    Created = movie.Created,
                    Img = movie.Picture_Path,
                    Description = movie.Description,
                    Trailer = movie.Trailer,
                    Rating = movie.Rating
                });
            }

            return View(Movies);
        }

        // GET: AgeRating
        public ActionResult MovieAgeRating(Nullable<int> id)
        {
            var data = LoadAgeRating(id);
            List<AgeRatingModel> AgeRaíting = new List<AgeRatingModel>();

            foreach (var rating in data)
            {
                AgeRaíting.Add(new AgeRatingModel
                {
                    ID = rating.ID,
                    Agerating = rating.AgeRestriction
                });
            }

            return View(AgeRaíting);
        }

        // GET: Genre
        public ActionResult MovieGenres(Nullable<int> id)
        {
            var data = LoadGenre(id);
            List<GenresModel> Genres = new List<GenresModel>();

            foreach (var Genre in data)
            {
                Genres.Add(new GenresModel
                {
                    Genre = Genre.Genre
                });
            }

            return View(Genres);
        }

        // GET: Directors
        public ActionResult MovieDirectors(Nullable<int> id)
        {
            var data = LoadDirector(id);
            List<DirectorModel> Directors = new List<DirectorModel>();

            foreach (var Director in data)
            {
                Directors.Add(new DirectorModel
                {
                    FirstName = Director.FirstName,
                    LastName = Director.LastName
                });
            }

            return View(Directors);
        }

        // GET: Directors
        public ActionResult MovieWriters(Nullable<int> id)
        {
            var data = LoadWriters(id);
            List<WriterModel> Directors = new List<WriterModel>();

            foreach (var Writer in data)
            {
                Directors.Add(new WriterModel
                {
                    FirstName = Writer.FirstName,
                    LastName = Writer.LastName
                });
            }

            return View(Directors);
        }

        // GET: Comments
        public ActionResult MovieComments(Nullable<int> id)
        {
            var data = LoadComments(id);
            List<CommentsModel> Comments = new List<CommentsModel>();

            foreach (var Comment in data)
            {
                Comments.Add(new CommentsModel
                {
                    ID = Comment.ID,
                    MovieID = Comment.MovieID,
                    Name = Comment.Name,
                    Created = Comment.Created,
                    Content = Comment.Content,
                    UserID = Comment.UserID
                });
            }

            return View(Comments);
        }

        // Get: Commentform
        public ActionResult Comment(int id)
        {
            CommentModel model = new CommentModel
            {
                MovieID = id
            };

            return View(model);
        }

        // Get: EditComment
        public ActionResult EditComment(int id)
        {
            if (Session["userID"] != null)
            {
                var data = LoadComment(id);
                if (Session["Group_ID"].ToString() == "2" || Convert.ToInt32(Session["userID"].ToString()) == data[0].UserID)
                {
                    CommentsModel comment = new CommentsModel
                    {
                        ID = data[0].ID,
                        Content = data[0].Content,
                        MovieID = data[0].MovieID
                    };

                    return View(comment);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // Get: CreatePeople
        public ActionResult CreatePeople()
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // Get: CreateGenre
        public ActionResult CreateGenre()
        {
            if (Session["UserID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // Get: CreateMovie
        public ActionResult CreateMovie()
        {
            if (Session["userID"] != null)
            {
                if (Session["Group_ID"].ToString() == "2")
                {
                    var ageRating = LoadAgeRating();
                    ViewBag.ageRating = new SelectList(ageRating, "ID", "AgeRestriction");

                    var genre = Loadgenre();
                    ViewBag.genre = new MultiSelectList(genre, "ID", "Genre");

                    var people = LoadPeople();
                    ViewBag.people = new MultiSelectList(people, "ID", "FirstName");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }
        // ----------------- Update Section ------------------

        [HttpPost]
        public ActionResult SaveEditComment(CommentsModel model)
        {
            if (Session["userID"] != null)
            {
                UpdateComment(model.ID, model.Content);
            }
            return RedirectToAction("MovieDetails", "Movie", new { id = model.MovieID });
        }

        // ----------------- Delete Section ------------------
        [HttpPost]
        public ActionResult DeletecommentMovie(Nullable<int> id, int MovieID)
        {
            if (Session["userID"] != null)
            {
                DeleteComment(id);
            }
            return RedirectToAction("MovieDetails", "Movie", new { id = MovieID });
        }
    }
}