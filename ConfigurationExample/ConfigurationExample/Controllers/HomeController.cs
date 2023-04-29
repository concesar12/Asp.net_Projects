using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options; // This was exported because we wanted to use IOptions interface

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //private field
        //private readonly IConfiguration _configuration; only for configuration
        private readonly WeatherApiOptions _options;

        //contructor
        //public HomeController(IConfiguration configuration) IConfiguration is the defined interface to get the configurations of settings.json
        public HomeController(IOptions<WeatherApiOptions> weatherApiOptions) //We are using IOptions instead of IConfiguration to use DI
        {
            _options = weatherApiOptions.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            //ViewBag.ClientSecret = _configuration.GetValue("weatherapi:ClientSecret", "the default client secret");

            //Get: Loads configuration values into existing options object 
            //WeatherApiOptions options = new WeatherApiOptions();
            //_configuration.GetSection("weatherapi").Bind(options);

            //Bind:  Loads configuration values into a new Options object
            //WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>(); // So I can receive in this object the options
            ViewBag.ClientID = _options.ClientID; // This is how to acces the value of the property THEY MUST HAVE THE SAME NAME TO WORK
            ViewBag.ClientSecret = _options.ClientSecret;
            return View();
        }
    }
}
