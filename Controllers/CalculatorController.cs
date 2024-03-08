using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GroupActivity.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static string previousDisplay = "";
        private static string currentDisplay = "0";
        private static bool evaluated = false;
        private static bool operation_added = false;

        [HttpGet]
        public IActionResult Clear()
        {
            previousDisplay = "";
            currentDisplay = "0";
            return Ok(new { previousDisplay , currentDisplay });
        }

        [HttpGet]
        public IActionResult DeleteDigit()
        {
            if (evaluated)
            {
                Clear();
                evaluated = false;
            }
            else
            {
                currentDisplay = currentDisplay.Length > 1 ? currentDisplay.Substring(0, currentDisplay.Length - 1) : "0";
            }
            return Ok(new { currentDisplay });
        }

        [HttpGet]
        public IActionResult AddDigit(int digit)
        {
            if (currentDisplay == "0" || evaluated)
            {
                currentDisplay = digit.ToString();
                evaluated = false;
            }
            else
            {
                currentDisplay += digit;
            }
            operation_added = false;
            return Ok(new { currentDisplay });
        }

        [HttpGet]
        public IActionResult AddDecimal()
        {
            if (evaluated)
            {
                Clear();
                evaluated = false;
            }
            if (!currentDisplay.Contains("."))
            {
                currentDisplay += ".";
            }
            return Ok(new { currentDisplay });
        }

        [HttpGet]
        public IActionResult ChooseOperation(string operation)
        {
            if (operation_added)
            {
                previousDisplay = previousDisplay.Substring(0, previousDisplay.Length - 1) + operation;
                return Ok(new { previousDisplay });
            }
            if (!string.IsNullOrEmpty(previousDisplay))
            {
                Evaluate();
            }
            previousDisplay = currentDisplay + operation;
            currentDisplay = "0";
            operation_added = true;
            evaluated = false;
            return Ok(new { previousDisplay, currentDisplay });
        }

        [HttpGet]
        public IActionResult Evaluate()
        {
            currentDisplay = new DataTable().Compute(previousDisplay + currentDisplay, null).ToString();
            previousDisplay = "";
            operation_added = false;
            evaluated = true;
            return Ok(new { previousDisplay, currentDisplay });
        }
    }
}
