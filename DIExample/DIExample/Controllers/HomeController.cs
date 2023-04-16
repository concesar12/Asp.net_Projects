using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts; 

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesServices _citiesService;

        //constructor
        public HomeController()
        {
            //Create object of CitiesService class
            _citiesService = null;//new CitiesService(); // This is bad practice, instead use Dependency injection
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService.GetCities();
            return View(cities);
        }
    }
}
