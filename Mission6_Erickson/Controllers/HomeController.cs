using System.Diagnostics;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using Mission6_Erickson.Models;

namespace Mission6_Erickson.Controllers
{
    public class HomeController : Controller
    {
        private MovieFormContext _context;

        public HomeController(MovieFormContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("MovieForm");
        }

        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            // Save the response to the database 
            _context.Forms.Add(response);

            _context.SaveChanges();

            return View("Confirmation", response);
        }

        public IActionResult MovieList()
        {
            //linq
            var forms = _context.Forms
                .Where(x => x.Edited == false)
                .OrderBy(x => x.MovieID).ToList();

            return View(forms);
        }
    }
}
