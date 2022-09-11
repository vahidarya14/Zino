using Microsoft.AspNetCore.Mvc;

namespace Zinoo.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
           return View();
        }

    }
}