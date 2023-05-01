using Microsoft.AspNetCore.Mvc;
using StocksApp.Services;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinnhubService _finnhubService;

        public HomeController(FinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        [Route("/")]
        public async Task<IActionResult> Index()
        {
            //We use in this way to be ablo to change the type the stock we want dynamically
            Dictionary<string, object>? responseDictionary = await _finnhubService.GetStockPriceQuote("MSFT"); // This is to read what has been passed as response
            return View();
        }
    }
}
