using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult CreateOrEditMovie()
        {
            var GenreTypes = _context.movieGenres.ToList();

            var viewModel = new NewMovieViewModel
            {
                MovieGenres = GenreTypes
            };

            return View("CreateOrEditMovie", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdateMovie(Movie movie)
        {
            ModelState.Remove("movie.Id");
            if (ModelState.IsValid)
            {
                if (movie.Id == 0)
                {
                    //movie.Genre = _context.movieGenres.Where(g => g.Id == movie.GenreId).FirstOrDefault();
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Registeration Successful";
                    return RedirectToAction("CreateOrEditMovie");

                }
                else
                {

                    _context.Entry(movie).State = EntityState.Modified;
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Details Updated Successfully";
                    return RedirectToAction("MovieList");
                }
            }
            return RedirectToAction("CreateOrEditMovie");


        }
        public ActionResult MovieList()
        {
            var viewModel = new MovieViewModel
            {
                Movies = _context.Movies.ToList(),
                Genres = _context.movieGenres.ToList()
            };
            return View(viewModel);
        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult RemoveMovie(int Id)
        {
            Movie movie = _context.Movies.Where(m => m.Id.Equals(Id)).First();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("CustomerList");

        }

        public ActionResult EditMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                MovieGenres = _context.movieGenres.ToList(),
            };
            return View("CreateOrEditMovie", viewModel);


        }
    }
}