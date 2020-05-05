using Microsoft.AspNetCore.Mvc;
namespace Razor_fun
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public ViewResult Index()
        {
            // This is going into the folder Views/Home → Index.cshtml
            return View("Index");
        }
    }
}