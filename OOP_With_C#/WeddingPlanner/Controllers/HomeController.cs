using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("new")]
        public IActionResult New(ThisWrapper newUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == newUser.ThisUser.Email))
                {
                    ModelState.AddModelError("ThisUser.Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newUser.ThisUser.Password = Hasher.HashPassword(newUser.ThisUser, newUser.ThisUser.Password);
                dbContext.Add(newUser.ThisUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.ThisUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else{
                return View("Index");
            }
        }
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            if(userid == null)
            {
                return View("Index");
            }
            else
            {
                ThisWrapper vMod = new ThisWrapper();
                vMod.AllWeddings = dbContext.Weddings
                    .Include(b => b.UsersfromWedding)
                    .ThenInclude(v => v.User)
                    .ToList();
                vMod.ThisUser = dbContext.Users
                    .FirstOrDefault(u => u.UserId == (int)userid);
                return View(vMod);
            }
        }
        [HttpPost("logged")]
        public IActionResult Logged(ThisWrapper logged)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == logged.ThisLoginUser.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("ThisLoginUser.Email", "Invalid Email/Password");
                    return View("Index");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(logged.ThisLoginUser, userInDb.Password, logged.ThisLoginUser.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("ThisLoginUser.Email", "Invalid Email/Password");
                    return View("Index");
                }
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        [HttpGet("wedding/{wedid}")]
        public IActionResult OneWedding(int wedid)
        {
            ThisWrapper vMod = new ThisWrapper();
            vMod.ThisWedding = dbContext.Weddings
                .Include(b => b.UsersfromWedding)
                .ThenInclude(v => v.User)
                .FirstOrDefault(b => b.WeddingId == wedid);
            return View(vMod);
        }
        [HttpPost("createwedding")]
        public IActionResult CreateWedding(Wedding thisWedding)
        {
            if(ModelState.IsValid)
            {
                int? userid = HttpContext.Session.GetInt32("UserId");
                User CurrentUser = dbContext.Users
                    .FirstOrDefault(u => u.UserId == (int)userid);
                Wedding newWedding = new Wedding
                {
                    WedderOne = thisWedding.WedderOne,
                    WedderTwo = thisWedding.WedderTwo,
                    Date = thisWedding.Date,
                    WeddingAddress = thisWedding.WeddingAddress,
                    Creator = CurrentUser
                };
                dbContext.Add(newWedding);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else{
                return View("Wedding");
            }
        }
        [HttpGet("wedding")]
        public IActionResult Wedding()
        {
            return View();
        }
        [HttpGet("delete/{wedid}")]
        public IActionResult Delete(int wedid)
        {
            var OneWed = dbContext.Weddings
                .FirstOrDefault(u => u.WeddingId == wedid);
            dbContext.Remove(OneWed);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        [HttpPost("rsvp/{wedid}")]
        public IActionResult RSVP(int wedid, ThisWrapper ThisUser)
        {
            ThisUser.Association.WeddingId = wedid;
            dbContext.Add(ThisUser.Association);
            dbContext.SaveChanges();
            return RedirectToAction("OneWedding", new {wedid = wedid});       
        }
        [HttpPost("unrsvp/{wedid}")]
        public IActionResult UnRSVP(int wedid)
        {
            int? userid = HttpContext.Session.GetInt32("UserId");
            var thisAsso = dbContext.Associations
                .FirstOrDefault(u => u.WeddingId == wedid && u.UserId == (int)userid );
            dbContext.Remove(thisAsso);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}
