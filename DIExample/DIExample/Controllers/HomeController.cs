using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts; 

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesServices _citiesService;

        //constructor
        public HomeController(ICitiesServices citiesService) // This is coming from the services for inversion of control // Constructor injection
        {
            //Create object of CitiesService class
            _citiesService = citiesService; //new CitiesService(); // This is bad practice, instead use Dependency injection
        }

        [Route("/")]
        public IActionResult Index()
        //public IActionResult Index([FromServices] ICitiesServices _citiesServices) // This comes from the service for DI // Method injection
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
