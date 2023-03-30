using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers // NameOfPrject.Folder
{

    public class HomeController : Controller // It is ncessary to suffix the wordcontroller for the class to be taken as a controller 
    {
        [Route("Home")] //It is required to define an attribute to specify the route // This is called attribute routing //
        [Route("/")] // Both work
        public ContentResult Index() // Method to be accessed // The name index relates to the main page // ContentResult will have the type to be responded 
        {
            //Instead
            //return Content("Hello from Index", "text/plain");
            //return new ContentResult() { Content = "Hello from Index", ContentType = "text/plain" }; // It is necessary to provide a valid content type
            //Try to return some html
            return Content("<h1>Hello, </h1>  <h2>This is Cesar</h2>", "text/html");
        }

        [Route("person")] 
        public JsonResult Person() 
        {
            Person person = new Person() { guid = Guid.NewGuid(), Firstname = "Cesar", Lastname="Guerrero", age=32 };
            return new JsonResult(person);
            //Instead of returning the long and confusion statement is better do it as above.
            //return "{\"key\" : \"value\"}"; //The reasonto put these "\" is because the other comillas are out of the brackets will no recognize the comillas inside
        }

        [Route("Contact-us/{mobile:regex(^\\d{{10}}$)}")] // This is to handle phones only get 10 digits double corchete and slash, because it need to be taken as the regular expression
        public string Contact() 
        {
            return "Hello from Contact";
        }
    }
}
