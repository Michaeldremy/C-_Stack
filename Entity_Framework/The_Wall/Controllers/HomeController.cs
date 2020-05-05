using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using The_Wall.Models;

namespace The_Wall.Controllers
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

        [HttpGet("login")]
        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpGet("thewall")]
        public IActionResult ViewTheWall()
        {
            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                WallWrapper vMod = new WallWrapper();
                int oneUserId = (int)HttpContext.Session.GetInt32("UserId");

                // This is grabbing all comments and it is showing who the user that created the comment.
                vMod.AllComments = dbContext.Comments
                .Include(c => c.User)
                .ThenInclude(c => c.CreatedComments)
                .ToList();

                // This is grabbing one user and the messages that they created.
                vMod.User = dbContext.Users
                .Include(u => u.CreatedMessages)
                .FirstOrDefault(u => u.UserId == oneUserId);

                // This is grabbing all the messages and including the comments and users under those messages.
                vMod.AllMessages = dbContext.Messages
                .Include(u => u.AllComments)
                .Include(u => u.User)
                .ThenInclude(u => u.CreatedMessages)
                .ToList();

                return View(vMod);
            }
        }
        
        [HttpGet("delete/{messageId}")]
        public IActionResult DeleteMessage (int messageId)
        {

            int? thisUserId = HttpContext.Session.GetInt32("UserId");
            if(thisUserId == null)
            {
                return View("Index");
            }
            else
            {
                // This is giving the user that is logged in to delete their own messages.
                int oneUserId = (int)thisUserId;
                Message thisMessage = dbContext.Messages
                    .FirstOrDefault(c => c.MessageId == messageId);
                dbContext.Remove(thisMessage);
                dbContext.SaveChanges();
                return RedirectToAction("ViewTheWall");
            }
        }


        // ---------- POST Requests -----------

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
            return RedirectToAction("ViewTheWall");
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
            return RedirectToAction("ViewTheWall");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("createmessage")]
        public IActionResult CreateMessage(WallWrapper fromForm)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            fromForm.Message.UserId = thisUserId;
            if (ModelState.IsValid)
            {
                dbContext.Add(fromForm.Message);
                dbContext.SaveChanges();
                return RedirectToAction("ViewTheWall", new { messageId = fromForm.Message.MessageId });
            }
            else
            {
                return View("ViewTheWall");
            }
        }

        [HttpPost("createcomment/{messageId}")]
        public IActionResult CreateComment(int messageId, WallWrapper fromForm)
        {
            int thisUserId = (int)HttpContext.Session.GetInt32("UserId");
            fromForm.Comment.UserId = thisUserId;
            if (ModelState.IsValid)
            {
                int oneUserId = (int)thisUserId;
                // Lines 147 - 148 is assigning fromForm.Comment which is in WallWrapper and grabbing the UserId and setting that to the one in Session.
                // Also it is grabbing the MessageId and assigning that to the messageId that is being passed through the POST route.
                // Line 149 is adding the whole WallWrapper model into the database.
                fromForm.Comment.UserId = oneUserId;
                fromForm.Comment.MessageId = messageId;
                dbContext.Add(fromForm.Comment);
                dbContext.SaveChanges();
                return RedirectToAction("ViewTheWall");
            }
            else
            {
                return View("ViewTheWall");
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
