using Microsoft.AspNetCore.Mvc;

namespace GroupActivity.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
