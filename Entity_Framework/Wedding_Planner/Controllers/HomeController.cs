using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Wedding_Planner.Models;


namespace Wedding_Planner.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        // ----------- GET REQUESTS -----------

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpGet("Dashboard")]
        public IActionResult Dashboard()
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                WeddingWrapper TheWeddings = new WeddingWrapper();
                int oneUserId = (int)HttpContext.Session.GetInt32("UserId");
                // This is grabbing the user in session, and then including the association to the user.
                TheWeddings.User = dbContext.Users
                    .Include(w => w.AllWeddings)
                    .ThenInclude(w => w.Wedding)
                    .FirstOrDefault(u => u.UserId == oneUserId);

                // This is showing all the weddings with the list of users attached to those weddings.
                TheWeddings.Weddings = dbContext.Weddings
                .Include(u => u.AllUsers)
                .ThenInclude( u => u.User)
                .ToList();
                
                return View(TheWeddings);
            }
        }

        [HttpGet("planwedding")]
        public IActionResult PlanWedding()
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("wedding/{weddingId}")]
        public IActionResult ViewOneWedding(int weddingId)
        {
            WeddingWrapper thisWedding = new WeddingWrapper();
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
            // This is querying to show all the users who are associated with a single wedding AKA RSVP.
            thisWedding.Wedding = dbContext.Weddings
                .Include(u => u.AllUsers)
                .ThenInclude(u => u.User)
                .SingleOrDefault(w => w.WeddingId == weddingId);

            return View(thisWedding);
            }
        }

        [HttpGet("delete/{weddingId}")]
        public IActionResult DeleteWedding(int weddingId)
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                // This is giving the user that is in session the ability to delete any weddings they are associated with.
                int oneUserId = (int)thisUserId;
                Wedding oneWedding = dbContext.Weddings
                    .FirstOrDefault(w => w.WeddingId == weddingId);
                    dbContext.Remove(oneWedding);
                    dbContext.SaveChanges();
                    return RedirectToAction("Dashboard");
            }
        }

        [HttpGet("rsvp/{weddingId}")]
        public IActionResult RSVP(int weddingId)
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                int oneUserId = (int)thisUserId;
                Association newAssociation = new Association();
                newAssociation.UserId = oneUserId;
                newAssociation.WeddingId = weddingId;
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet("unrsvp/{weddingId}")]
        public IActionResult UNRSVP(int weddingId)
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                int oneUserId = (int)thisUserId;
                Association thisAssociation = new Association();
                thisAssociation = dbContext.Associations
                    .FirstOrDefault(t => t.UserId == oneUserId && t.WeddingId == weddingId);
                dbContext.Remove(thisAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        // ----------- POST REQUESTS -----------

        [HttpPost("login")]
        public IActionResult Login(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDb = dbContext.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LoginPage");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("LoginPage");
                }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Dashboard");
            }
            return View("LoginPage");
        }
        [HttpPost("register")]
        public IActionResult Register(User regUser)
        {
            if (ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == regUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("Index");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                regUser.Password = Hasher.HashPassword(regUser, regUser.Password);
                dbContext.Add(regUser);
                dbContext.SaveChanges();
                // Line 69 is using Session
                HttpContext.Session.SetInt32("UserId", regUser.UserId);
            return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("createwedding")]
        public IActionResult CreateWedding(Wedding fromForm)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            fromForm.UserId = thisUserId;
            if (ModelState.IsValid)
            {
                dbContext.Add(fromForm);
                dbContext.SaveChanges();
                return RedirectToAction("ViewOneWedding", new { weddingId = fromForm.WeddingId });
            }
            else
            {
                return View("PlanWedding", fromForm);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
