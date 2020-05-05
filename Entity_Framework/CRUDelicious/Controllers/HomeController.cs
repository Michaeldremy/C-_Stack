using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        // Lines 14 - 19 are making it where we can use our Database within our controller.
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        // routes to localhost:5000
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Dish> AllDishs = dbContext.Dishs.OrderByDescending(d => d.CreatedAt).ToList();
            return View(AllDishs);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("createdish")]
        public IActionResult CreateDish(Dish newDishFromForm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDishFromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index", newDishFromForm);
            }
            else
            {
                return View("New", newDishFromForm);
            }
        }
        [HttpGet("{dishId}")]
        public IActionResult DisplayDish(int dishId)
        {
            Dish oneDish = dbContext.Dishs.SingleOrDefault(d => d.DishId == dishId);
            return View(oneDish);
        }

        [HttpGet("edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish ToEdit = dbContext.Dishs.SingleOrDefault(d => d.DishId == dishId);
            return View(ToEdit);
        }

        [HttpPost("updatedish/{dishId}")]
        public IActionResult UpdateDish(int dishId, Dish dishFromForm)
        {
            if(ModelState.IsValid)
            {
                // Lines 68 - 71: This taking the submitted from when you edit and it is ignoring the "CreatedAt" property in our Database.
                dishFromForm.DishId = dishId;
                dbContext.Update(dishFromForm);
                dbContext.Entry(dishFromForm).Property("CreatedAt").IsModified = false;
                dbContext.SaveChanges();
            return RedirectToAction("DisplayDish");
            }
            else
            {
                return View("EditDish", dishFromForm);
            }
        }

        [HttpGet("delete/{dishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish ToDelete = dbContext.Dishs.SingleOrDefault(d => d.DishId == dishId);
            dbContext.Dishs.Remove(ToDelete);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
