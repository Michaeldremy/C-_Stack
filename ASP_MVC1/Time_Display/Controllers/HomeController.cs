using Microsoft.AspNetCore.Mvc;
// ***Change namespace to the Folder name***
namespace Time_Display
{
    public class HomeController : Controller
    {
        // Requests
        // localhost:5000/
        [HttpGet("")]
        public ViewResult Index()
    {
        return View("Index");
    }
    }
}