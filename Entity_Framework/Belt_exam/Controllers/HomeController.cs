using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Belt_exam.Models;

namespace Belt_exam.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("beltdashboard")]
        public IActionResult BeltDashboard()
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                BeltWrapper vMod = new BeltWrapper();
                int oneUserId = (int)HttpContext.Session.GetInt32("UserId");

                vMod.User = dbContext.Users
                .Include(u => u.CreatedAssociation)
                .ThenInclude(s => s.Sport)
                .FirstOrDefault(u => u.UserId == oneUserId);

                vMod.AllSports = dbContext.Sports
                .Include(u => u.AllAssociations)
                .Include(u => u.User)
                .ThenInclude(u => u.CreatedSports)
                .OrderBy(d => d.Date)
                .ToList();
                // Also don't forget to use linq queries to display information
                // Don't forget to redirect to the approiate Method
                return View(vMod);
            }
        }

        [HttpGet("planactivity")]
        public IActionResult PlanActivity()
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
        
        [HttpGet("activity/{sportId}")]
        public IActionResult ViewOneActivity(int sportId)
        {
            BeltWrapper oneSport = new BeltWrapper();
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                int oneUserId = (int)HttpContext.Session.GetInt32("UserId");
                oneSport.Sport = dbContext.Sports
                .Include(s => s.AllAssociations)
                .ThenInclude(u => u.User)
                .SingleOrDefault(s => s.SportId == sportId);

                oneSport.AllSports = dbContext.Sports
                .Include(u => u.AllAssociations)
                .ToList();

                oneSport.User = dbContext.Users
                .Include(u => u.CreatedAssociation)
                .ThenInclude(s => s.Sport)
                .FirstOrDefault(u => u.UserId == oneUserId);

                return View(oneSport);
            }
        }

        [HttpGet("delete/{sportId}")]
        public IActionResult DeleteSport(int sportId)
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                int oneUserId = (int)thisUserId;
                Sport oneSport = dbContext.Sports
                .FirstOrDefault(s => s.SportId == sportId);
                dbContext.Remove(oneSport);
                dbContext.SaveChanges();
                return RedirectToAction("BeltDashboard");
            }
        }

        [HttpGet("leave/{sportId}")]
        public IActionResult LeaveSport(int sportId)
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
                .FirstOrDefault(t => t.UserId == oneUserId && t.SportId == sportId);
                dbContext.Remove(thisAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("BeltDashboard");
            }
        }

        [HttpGet("join/{sportId}")]
        public IActionResult JoinSport(int sportId)
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
                newAssociation.SportId = sportId;
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("BeltDashboard");
            }
        }

        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View();
        }


        // ------- POST REQUESTS --------

        [HttpPost("createactivity")]
        public IActionResult CreateActivity(Sport fromForm)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            fromForm.UserId = thisUserId;
            if (ModelState.IsValid)
            {
                if (fromForm.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Please enter a date that is in the future.");
                    return View("PlanActivity");
                }
                dbContext.Add(fromForm);
                dbContext.SaveChanges();
                return RedirectToAction("ViewOneActivity", new { sportId = fromForm.SportId});
            }
            else
            {
                return View("PlanActivity");
            }
        }

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
            return RedirectToAction("BeltDashboard");
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
            return RedirectToAction("BeltDashboard");
            }
            else
            {
                return View("Index");
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
