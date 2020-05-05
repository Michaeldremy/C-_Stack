using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string[] strArrray = new string[]
            {
                "This is an assignment to learn how we can use models instead of ViewBag!",
                "This assignment was a challenge!"
            };
            return View(strArrray);
        }
        // localhost:5000/numbers
        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] oneArray = new int []
            {
                5,6,7,8,9,10
            };
            return View(oneArray);
        }
        // localhost:5000/user
        [HttpGet("user")]
        public IActionResult UserPage()
        {
            User oneUser = new User()
            {
                FirstName = "Michael",
                LastName = "Remy"
            };
            return View(oneUser);
        }
        // localhost:5000/users
        [HttpGet("users")]
        public IActionResult UsersPage()
        {
            User someUser = new User()
            {
                FirstName = "Michael",
                LastName = "Remy"
            };
            User anotherUser = new User()
            {
                FirstName = "Rachel",
                LastName = "Remy"
            };
            List<User> viewUser = new List<User>()
            {
                someUser, anotherUser
            };
            return View(viewUser);
        }
    }
}
