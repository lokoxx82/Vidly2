using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #region Edit
        public ActionResult Edit(int? id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);

            MovieFormViewModel movieFormViewModel = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypeses.ToList()
            };

            if (movie == null)
            {

                return View("MovieForm", movieFormViewModel);
            }

            movieFormViewModel.Movie = movie;

            return View("MovieForm", movieFormViewModel);
        }
        #endregion


        #region Movies
        public ActionResult Movies()
        {
            MoviesModel moviesModel = new MoviesModel()
            {
                Movies = _context.Movies.Include(c => c.Genre).ToList().OrderBy(x=>x.Name)
            };


              return View(moviesModel);
        }
        #endregion

        #region Movie

        [Route("movies/movie/{id}")]
        public ActionResult Movie(int? id)
        {
            MoviesModel moviesModel = new MoviesModel()
            {
                Movies = _context.Movies.Include(c => c.Genre).ToList()

            };

            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            Movie movie = moviesModel.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        #endregion

        #region Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(MovieFormViewModel movieFormViewModel)
        {
            movieFormViewModel.GenreTypes = _context.GenreTypeses.ToList();
            movieFormViewModel.Movie.Genre = _context.GenreTypeses.ToList().FirstOrDefault(x => x.Id == movieFormViewModel.Movie.GenreId);
            Movie movie = movieFormViewModel.Movie;

            bool state =  ModelState.Values.All(m => m.Errors.Count == 0);
            if (!ModelState.IsValid)
            {
                movieFormViewModel.GenreTypes = _context.GenreTypeses;
                return View("MovieForm", movieFormViewModel);
            }
            

            if (!movie.Id.HasValue)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                Movie movieInDb = _context.Movies.FirstOrDefault(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Movies", "Movies");
        } 
        #endregion
    }
}