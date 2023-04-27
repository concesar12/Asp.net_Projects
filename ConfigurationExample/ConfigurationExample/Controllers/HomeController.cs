using Microsoft.AspNetCore.Mvc;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //private field
        private readonly IConfiguration _configuration;

        //contructor
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            //ViewBag.ClientSecret = _configuration.GetValue("weatherapi:ClientSecret", "the default client secret");
            IConfigurationSection weatherapiSection = _configuration.GetSection("weatherapi");
            ViewBag.ClientID = weatherapiSection["ClientID"];
            ViewBag.ClientSecret = weatherapiSection["ClientSecret"];
            return View();
        }
    }
}
