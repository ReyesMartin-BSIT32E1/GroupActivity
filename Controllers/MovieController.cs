using GroupActivity.Data;
using GroupActivity.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupActivity.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string searchQuery)
        {
            IQueryable<Movie> movies = _db.Movies;

            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                movies = movies.Where(m => m.Title.ToLower().Contains(searchQuery));
            }

            List<Movie> objMovieList = movies.ToList();
            return View(objMovieList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Movie obj)
        {
            if (!ModelState.IsValid) return View();
            _db.Movies.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
