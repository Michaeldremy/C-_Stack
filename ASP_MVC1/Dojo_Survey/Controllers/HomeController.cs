using Microsoft.AspNetCore.Mvc;
using Dojo_Survey.Models;
using System.Collections.Generic;
// ***Change namespace to the Folder name***
namespace Dojo_Survey
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public IActionResult Index()
    {
        return View("Index");
    }
        // localhost:5000/result
        [HttpPost("result")]
        public IActionResult Result(DojoSurvey yourSurvey)
        {
            if(ModelState.IsValid)
            {
                return View(yourSurvey);
            }
            else
            {
                return View("Index", yourSurvey);
            }
        }
    }
}