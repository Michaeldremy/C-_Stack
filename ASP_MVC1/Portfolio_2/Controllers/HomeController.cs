using Microsoft.AspNetCore.Mvc;
namespace Portfolio_2
{
    public class HomeController : Controller
    {
        // Requsts
        // localhost:5000/
        [HttpGet("")]
        public ViewResult Index()
        {
            // This is going into the folder Views/Hello → Index.cshtml
            // View will search in the top folder (Hello) and then the Shared folder
            return View("Index");
        }
        // localhost:5000/projects
        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View("projects");
        }
        // localhost:5000/contact
        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View("Contact");
        }
    }
}