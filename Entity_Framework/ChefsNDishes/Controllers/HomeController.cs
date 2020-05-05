using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.Include(d => d.CreatedDishes).ToList();
            return View("Index", AllChefs);
        }
        [HttpGet("dishes")]
        public IActionResult DisplayDishes()
        {
            List<Dish> AllDishes = dbContext.Dishes.Include(d => d.Creator).ToList();
            return View("DisplayDishes", AllDishes);
        }
        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.ViewChefs = dbContext.Chefs.ToList();
            return View("NewDish");
        }
        [HttpPost("createdish")]
        public IActionResult CreateDish(Dish newDishFromForm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newDishFromForm);
                dbContext.SaveChanges();
                return RedirectToAction("DisplayDishes", newDishFromForm);
            }
            else
            {
                ViewBag.ViewChefs = dbContext.Chefs.ToList();
                return View("NewDish", newDishFromForm);
            }
        }
        [HttpGet("newchef")]
        public IActionResult NewChef()
        {
            return View("NewChef");
        }
        [HttpPost("createchef")]
        public IActionResult CreateChef(Chef newChefFromForm)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(newChefFromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef", newChefFromForm);
            }
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
