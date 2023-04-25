using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        //contrusctor 
        public HomeController(IWebHostEnvironment webHostEnvironment) // injection of the service to get the environment variable
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //_webHostEnvironment.IsDevelopment(); //this one comes from the constructor which was injected the service  IWebHostEnvironment
            ViewBag.CurrentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }
    }
}
