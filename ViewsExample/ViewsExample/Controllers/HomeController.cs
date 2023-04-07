using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            return View(); //Views/Home/Index.cshtml
            //return View("abc"); // abc.cshtml
            //return new ViewResult() { ViewName = "abc" }; this is the long way to very used in the real projects
        }
    }
}
