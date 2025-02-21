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
            return View("MovieForm", new Form());
        }

        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            if (ModelState.IsValid)
            {
               // Save the response to the database 
                _context.Forms.Add(response);

                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else //Invalid data
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(response);
            }
            
        }

        public IActionResult MovieList()
        {
            //linq
            var forms = _context.Forms
                .Where(x => x.Edited == false)
                .OrderBy(x => x.MovieID).ToList();

            return View(forms);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var RecordToEdit = _context.Forms
                .Single(x => x.MovieID == id);

            ViewBag.Categories = _context.Categories
              .OrderBy(x => x.CategoryName)
              .ToList();

            return View("MovieForm", RecordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Form updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var RecordToDelete = _context.Forms
                .Single(x => x.MovieID == id);

            return View(RecordToDelete);

        }

        [HttpPost]
        public IActionResult Delete(Form form)
        {
            _context.Forms.Remove(form);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
