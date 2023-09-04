using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        // public String Index()
        // {
        //     return "Hello from Home Controller!";
        // }
    }
}