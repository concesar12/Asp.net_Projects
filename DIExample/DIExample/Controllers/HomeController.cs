using Microsoft.AspNetCore.Mvc;
using Services;
using ServiceContracts; 

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesServices _citiesService;
        private readonly ICitiesServices _citiesService2;
        private readonly ICitiesServices _citiesService3;


        //constructor
        public HomeController(ICitiesServices citiesService, ICitiesServices citiesService2, ICitiesServices citiesService3) // This is coming from the services for inversion of control // Constructor injection
        {
            //Create object of CitiesService class
            _citiesService = citiesService; //new CitiesService(); // This is bad practice, instead use Dependency injection
            _citiesService2 = citiesService2;
            _citiesService3 = citiesService3;
        }

        [Route("/")]
        public IActionResult Index()
        //public IActionResult Index([FromServices] ICitiesServices _citiesServices) // This comes from the service for DI // Method injection
        {
            List<string> cities = _citiesService.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;
            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            return View(cities);
        }
    }
}
