using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid) // This propperty will check the status of the attributes in the model
            {
                /*This will be done using LINQ to make it easier*/
                //List<string> errorsList = new List<string>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors) // This will get all the errors of all propperties
                //    {
                //        errorsList.Add(error.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorsList);
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));
                //List<string> errorsList = ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList(); // Old way to do it
                return BadRequest(errors);
            }
            return Content($"{person}");
        }
    }
}
