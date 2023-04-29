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

            //Get: Loads configuration values into existing options object 
            WeatherApiOptions options = new WeatherApiOptions();
            _configuration.GetSection("weatherapi").Bind(options);

            //Bind:  Loads configuration values into a new Options object
            //WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>(); // So I can receive in this object the options
            ViewBag.ClientID = options.ClientID; // This is how to acces the value of the property THEY MUST HAVE THE SAME NAME TO WORK
            ViewBag.ClientSecret = options.ClientSecret;
            return View();
        }
    }
}
