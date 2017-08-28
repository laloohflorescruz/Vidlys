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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            
            //var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View("ReadOnlyList");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles=RoleName.CanManageMovies)]
        public ViewResult New()
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
        [Authorize(Roles = RoleName.CanManageMovies)]
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

            return RedirectToAction("Index","Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null) return HttpNotFound();

            var viewModel = new RandomMovieViewModel(movie)
            {
                //Id = movie.Id,
                //Name= movie.Name,
                //Release = movie.Release,
                //Stock = movie.Stock,
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}