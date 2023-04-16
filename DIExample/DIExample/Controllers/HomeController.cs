using Microsoft.AspNetCore.Mvc;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesService _citiesService;

        //constructor
        public HomeController()
        {
            //Create object of CitiesService class
            _citiesService = new CitiesService(); // This is bad practice, instead use Dependency injection
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
