using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BankAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BankAccounts.Controllersw
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
            return RedirectToAction("DisplayAccount", new { userId = userInDb.UserId });
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
            return RedirectToAction("DisplayAccount", new { userId = regUser.UserId });
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("account/{userId}")]
        public IActionResult DisplayAccount(int userId)
        {
            // This is grabbing one user and their transactions and then it is adding the transactions to get the total balance left over.
            User thisUser = dbContext.Users
                .Include(u => u.CreatedTransactions).SingleOrDefault(u => u.UserId == userId);
            ViewBag.oneUser = thisUser;
            decimal Sum = 0;
            ViewBag.Balance = dbContext.Transactions.ToList();
            foreach (var item in thisUser.CreatedTransactions)
            {
                Sum += item.Amount;
            }
            ViewBag.Balance = Sum;
            // Lines 82 - 90 will need to be used on every page after you Login!
            string email = HttpContext.Session.GetString("UserId");
            if(email == null)
            {
                return View("Index");
            }
            else
            {
                return View();
            }
            // return View();
        }
        [HttpPost("updatebalance")]
        public IActionResult UpdateBalance(Transaction tFromForm)
        {
            int ThisUserId = (int)HttpContext.Session.GetInt32("UserId");
            User thisUser = dbContext.Users
                .Include(u => u.CreatedTransactions).SingleOrDefault(u => u.UserId == ThisUserId);
            decimal Sum = 0;
            foreach (var item in thisUser.CreatedTransactions)
            {
                Sum += item.Amount;
            }
            ViewBag.Balance = Sum;
            if (ModelState.IsValid)
            {
                if ((Sum + tFromForm.Amount) < 0)
                {
                    ModelState.AddModelError("Amount", "Not enough funds");
                    ViewBag.oneUser = thisUser;
                    return View("DisplayAccount");
                }
                tFromForm.UserId = (int)HttpContext.Session.GetInt32("UserId");
                dbContext.Add(tFromForm);
                dbContext.SaveChanges();
            return RedirectToAction("DisplayAccount", new { userId = tFromForm.UserId });
            }
            else
            {
                return View("DisplayAccount", tFromForm);
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
