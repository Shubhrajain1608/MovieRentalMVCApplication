using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalMVCApplication.ViewModel;

namespace MovieRentalMVCApplication.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _context;
        // GET: Movie

        public MovieController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult Details(int? id)
        {
            var movies = _context.Movies.Include(c => c.Genere).SingleOrDefault(c => c.Id == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genere).ToList();
            return View(movies);

        }
        public ActionResult Edit(int? id)
        {

            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);//eager loading
            if (movies == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movies,
                Generes = _context.Generes.ToList()
            };
            return View("New", viewModel);

        }
        public ActionResult New()
        {
            var Generes = _context.Generes.ToList();
            var viewModel = new NewMovieViewModel
            {
               
                Generes = _context.Generes.ToList()

            };


            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            //if (ModelState.IsValid)
            //{
            //    var viewModel = new NewMovieViewModel
            //    {
                  
            //        Generes = _context.Generes.ToList()
            //    };
            //    return View("New", viewModel);
            //}

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
               
                movieInDb.MovieName = movie.MovieName;
                movieInDb.Releasedate = movie.Releasedate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.stock = movie.stock;
                movieInDb.GenereId = movie.GenereId;
              

            }
            _context.SaveChanges();//link to entity
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult Back()
        {
            return RedirectToAction("Index", "Movie");
        }
        

    }

}
