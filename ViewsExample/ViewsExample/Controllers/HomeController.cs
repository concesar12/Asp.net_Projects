using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Example page";
            List<Person> people = new List<Person>()
            {
                new Person() { Name = "Cesar", DateOfBirth = DateTime.Parse("1993-04-05"), PersonGender = Gender.Male },
                new Person() { Name = "Marcela", DateOfBirth = DateTime.Parse("1995-06-12"), PersonGender = Gender.Female },
                new Person() { Name = "Laisa", DateOfBirth = DateTime.Parse("2000-11-11"), PersonGender = Gender.Other },

            };
            //ViewData["people"] = people;
            ViewBag.people = people;
            return View(); //Views/Home/Index.cshtml
            //return View("abc"); // abc.cshtml
            //return new ViewResult() { ViewName = "abc" }; this is the long way to very used in the real projects

        }
    }
}
