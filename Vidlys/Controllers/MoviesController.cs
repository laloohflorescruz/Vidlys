using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Vidlys.ViewModels;
using Vidlys.Models;

namespace Vidlys.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new RandomMovieViewModel
            {
                Genre = genre
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RandomMovieViewModel(movie)
                {
                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.Release = movie.Release;
                movieInDb.Stock = movie.Stock;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();

            return View("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Genre = _context.Genre.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            var customer = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (id == null)
            {
                return Content("Seleccione un Id válido");
            }
            if (customer == null) return HttpNotFound();

            return View(customer);
        }
    }
}