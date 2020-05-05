using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using belt2_exam.Models;

namespace belt2_exam.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
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
                BeltWrapper vMod = new BeltWrapper();
                int oneUserId = (int)HttpContext.Session.GetInt32("UserId");

                vMod.Hobbies = dbContext.Hobbies
                .Include(u => u.AllAssociations)
                .Include(u => u.User)
                .ThenInclude(u => u.CreatedHobbies)
                .ToList();

                vMod.User = dbContext.Users
                .Include(u => u.CreatedAssociations)
                .ThenInclude(h => h.Hobby)
                .FirstOrDefault(u => u.UserId == oneUserId);

                return View(vMod);
            }
        }

        [HttpGet("hobby/{hobbyId}")]
        public IActionResult ViewOneHobby(int hobbyId)
        {
            BeltWrapper oneHobby = new BeltWrapper();
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                int oneUserId = (int)HttpContext.Session.GetInt32("UserId");
                oneHobby.Hobby = dbContext.Hobbies
                .Include(h => h.AllAssociations)
                .ThenInclude(u => u.User)
                .SingleOrDefault(h => h.HobbyId == hobbyId);

                oneHobby.Hobbies = dbContext.Hobbies
                .Include(u => u.AllAssociations)
                .Include(u => u.User)
                .ThenInclude(u => u.CreatedHobbies)
                .ToList();

                oneHobby.User = dbContext.Users
                .Include(u => u.CreatedAssociations)
                .ThenInclude(h => h.Hobby)
                .FirstOrDefault(u => u.UserId == oneUserId);

                oneHobby.Proficiencies = dbContext.Proficiencies
                .Include(u => u.User)
                .ThenInclude(p => p.CreatedProficiencyLevels)
                .ToList();

                return View(oneHobby);
            }
        }

        [HttpGet("join/{hobbyId}")]
        public IActionResult JoinHobby(int hobbyId)
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
                newAssociation.HobbyId = hobbyId;
                dbContext.Add(newAssociation);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

        [HttpGet("Hobby/New")]
        public IActionResult MakeHobby()
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

        [HttpPost("addhobbylevel/{proficiencyId}")]
        public IActionResult HPAssociation(int proficiencyId, BeltWrapper fromForm)
        {
            fromForm.Association.ProficiencyId = proficiencyId;
            dbContext.Add(fromForm.Association);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpPost("Hobby/createhobby")]
        public IActionResult CreateHobby(Hobby fromForm)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            fromForm.UserId = thisUserId;
            if (ModelState.IsValid)
            {
                dbContext.Add(fromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("MakeHobby");
            }
        }

        [HttpPost("logged")]
        public IActionResult Logged(LogRegWrapper logged)
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

        [HttpPost("new")]
        public IActionResult New(LogRegWrapper newUser)
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
