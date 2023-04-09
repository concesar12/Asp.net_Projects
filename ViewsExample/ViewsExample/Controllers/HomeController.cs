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
            //ViewBag.people = people;
            return View("Index", people); //Views/Home/Index.cshtml // The argument people is provided only when @model added in the view // In case those data is meant for a specific view
            //return View("abc"); // abc.cshtml
            //return new ViewResult() { ViewName = "abc" }; this is the long way to very used in the real projects
        }
        [Route("person-details/{name}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
                return Content("Person name can't be null");

            List<Person> people = new List<Person>()
            {
                new Person() { Name = "Cesar", DateOfBirth = DateTime.Parse("1993-04-05"), PersonGender = Gender.Male },
                new Person() { Name = "Marcela", DateOfBirth = DateTime.Parse("1995-06-12"), PersonGender = Gender.Female },
                new Person() { Name = "Laisa", DateOfBirth = DateTime.Parse("2000-11-11"), PersonGender = Gender.Other },
            };
            Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();
            return View(matchingPerson); // Views/Home/Details.cshtml // So this view will have the mathing person in the url /person-details/Cesar
        }
        [Route("person-and-product")]
        public IActionResult PersonAndProduct()
        {
            Person person = new Person() { Name = "Sara", PersonGender = Gender.Female, DateOfBirth = Convert.ToDateTime("2004-07-01") };

            Product product = new Product() { ProductId = 1, ProductName = "Air Conditioner" };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product }; 
            return View(personAndProductWrapperModel);
        }
    }
}
