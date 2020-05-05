using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Random_Passcode2.Models;
using Microsoft.AspNetCore.Http;

namespace Random_Passcode2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("count") == null)
            {
                HttpContext.Session.SetInt32("count", 5);
            }

            RandString newRandStr = new RandString(14);
            string randPasscode = newRandStr.LettersNums;
            ViewBag.Count = HttpContext.Session.GetInt32("count");
            ViewBag.randPasscode = randPasscode;
            return View();
        }

        [HttpPost("generate")]
        public IActionResult Generate()
        {
            int? count = HttpContext.Session.GetInt32("count");
            count += 1;
            HttpContext.Session.SetInt32("count", count.GetValueOrDefault());
            return RedirectToAction("Index");
        }
        
        [HttpPost("clear")]
        public IActionResult Clear()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
