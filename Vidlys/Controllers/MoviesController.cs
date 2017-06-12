using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidlys.Models;
using Vidlys.ViewModels;
using System.Data.Entity;


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
            var movies = _context.Movies.ToList();

            return View(movies);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
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