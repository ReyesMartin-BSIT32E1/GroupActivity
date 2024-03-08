using GroupActivity.Data;
using GroupActivity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupActivity.Controllers
{
    public class QuoteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public QuoteController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RandomQuote()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _db.Quotes.Count());
            Quote randomQuote = _db.Quotes.Skip(randomIndex).FirstOrDefault();
            return Json(randomQuote);
        }
    }
}