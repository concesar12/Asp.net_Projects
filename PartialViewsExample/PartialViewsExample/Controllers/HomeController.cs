using Microsoft.AspNetCore.Mvc;
using PartialViewsExample.Models;

namespace PartialViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //ViewData["ListTitle"] = "Cities";
            //ViewData["ListItems"] = new List<string>()
            //{
            //    "Teusaquillo",
            //    "Fontibon",
            //    "Usaquen",
            //    "Kenedy"
            //};
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listModel = new ListModel()
            {
                ListTitle = "Programming Languages List",
                ListItems = new List<string>() {
          "Python",
          "C#",
          "Go"
        }
            };

            //return new PartialViewResult() { ViewName = "_ListPartialView", Model = ListModel }; Long version
            return PartialView("_ListPartialView", listModel); // This is the partial view to be returned
        }
    }
}
