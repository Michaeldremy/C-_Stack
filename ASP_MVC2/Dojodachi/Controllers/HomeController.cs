using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("fullness") == null)
            {
                HttpContext.Session.SetInt32("fullness", 20);
            }
            if (HttpContext.Session.GetInt32("happiness") == null)
            {
                HttpContext.Session.SetInt32("happiness", 20);
            }
            if (HttpContext.Session.GetInt32("meals") == null)
            {
                HttpContext.Session.SetInt32("meals", 3);
            }
            if (HttpContext.Session.GetInt32("energy") == null)
            {
                HttpContext.Session.SetInt32("energy", 50);
            }
            if (HttpContext.Session.GetString("message") == null)
            {
                HttpContext.Session.SetString("message", "Welcome to Dojodachi! Click the buttons below to start your game.");
            }

            ViewBag.Fullness = HttpContext.Session.GetInt32("fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("happiness");
            ViewBag.Meals = HttpContext.Session.GetInt32("meals");
            ViewBag.Energy = HttpContext.Session.GetInt32("energy");
            ViewBag.Message = HttpContext.Session.GetString("message");

            return View();
        }
        [HttpPost("feeding")]
        public IActionResult Feeding()
        {
            Pet d1 = new Pet();
            d1.Feeding(HttpContext.Session.GetInt32("meals").GetValueOrDefault(), HttpContext.Session.GetInt32("fullness").GetValueOrDefault(), HttpContext.Session.GetString("message"));
            HttpContext.Session.SetInt32("fullness",d1.Fullness);
            HttpContext.Session.SetInt32("meals", d1.Meals);
            HttpContext.Session.SetString("message", d1.Message);
            return RedirectToAction("Index");
        }
        [HttpPost("playing")]
        public IActionResult Playing()
        {
            Pet d1 = new Pet();
            d1.Playing(HttpContext.Session.GetInt32("energy").GetValueOrDefault(), HttpContext.Session.GetInt32("happiness").GetValueOrDefault(), HttpContext.Session.GetString("message"));
            HttpContext.Session.SetInt32("energy", d1.Energy);
            HttpContext.Session.SetInt32("happiness", d1.Happiness);
            HttpContext.Session.SetString("message", d1.Message);
            return RedirectToAction("Index");
        }

        [HttpPost("working")]
        public IActionResult Working()
        {
            Pet d1 = new Pet();
            d1.Working(HttpContext.Session.GetInt32("energy").GetValueOrDefault(), HttpContext.Session.GetInt32("meals").GetValueOrDefault(), HttpContext.Session.GetString("message"));
            HttpContext.Session.SetInt32("energy", d1.Energy);
            HttpContext.Session.SetInt32("meals", d1.Meals);
            HttpContext.Session.SetString("message", d1.Message);
            return RedirectToAction("Index");
        }
        [HttpPost("sleeping")]
        public IActionResult Sleeping()
        {
            Pet d1 = new Pet();
            d1.Sleeping(HttpContext.Session.GetInt32("energy").GetValueOrDefault(), HttpContext.Session.GetInt32("fullness").GetValueOrDefault(), HttpContext.Session.GetInt32("happiness").GetValueOrDefault(), HttpContext.Session.GetString("message"));
            HttpContext.Session.SetInt32("energy", d1.Energy);
            HttpContext.Session.SetInt32("fullness", d1.Fullness);
            HttpContext.Session.SetInt32("happiness", d1.Happiness);
            HttpContext.Session.SetString("message", d1.Message);
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
