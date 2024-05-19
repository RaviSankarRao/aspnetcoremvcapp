using Microsoft.AspNetCore.Mvc;

namespace aspnetcoremvcapp.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
