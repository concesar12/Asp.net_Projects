using Microsoft.AspNetCore.Mvc;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyService _myServicec;

        public HomeController(MyService myService)
        {
            _myServicec = myService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            await _myServicec.method();
            return View();
        }
    }
}
