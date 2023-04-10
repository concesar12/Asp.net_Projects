using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products/all")]
        public IActionResult All()
        {
            return View();
            //Views/Products/All.cshtml
            //If not present //Views/Shared/All.cshtml
        }
    }
}
