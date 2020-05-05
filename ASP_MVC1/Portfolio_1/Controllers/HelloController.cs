using Microsoft.AspNetCore.Mvc;
namespace Portfolio_1
{
    public class HelloController : Controller
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
        public RedirectToActionResult Projects()
        {
            System.Console.WriteLine("Hello there, this has redirected back to home!");
            return RedirectToAction("projects");
        }
        // localhost:5000/contact
        [HttpGet("contact")]
        public string Contact()
        {
            return "Want to hire me? Contact me at example@gmail.com";
        }
    }
}