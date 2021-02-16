﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static FlickClick_ClassLibary.BusinessLogic.MovieProcess;
using Flick_Click.Models;

namespace Flick_Click.Controllers
{
    public class MovieController : Controller
    {
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

        // ----------------- Movie Details Section ------------------

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
            List<GenreModel> Genres = new List<GenreModel>();

            foreach (var Genre in data)
            {
                Genres.Add(new GenreModel
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
    }
}