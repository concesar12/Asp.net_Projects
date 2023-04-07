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
            return Json(person); // This is the shortest and best way to return a json
            //return new JsonResult(person); other way to return json
            //Instead of returning the long and confusion statement is better do it as above.
            //return "{\"key\" : \"value\"}"; //The reasonto put these "\" is because the other comillas are out of the brackets will no recognize the comillas inside
        }

        [Route("file-download")] 
        public VirtualFileResult FileDownload() 
        {
            //return new VirtualFileResult("/sample.pdf", "application/pdf"); //use this when on wwroot
            //Better this way
            return File("/sample.pdf", "application/pdf"); //use this when on wwroot

        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"D:\Cesar\Udemy\Projects&examples\multimedia\docs.pdf", "application/pdf"); //use this outside wwroot
            //Better this way
            return PhysicalFile(@"D:\Cesar\Udemy\Projects&examples\multimedia\docs.pdf", "application/pdf"); //use this outside wwroot
        }

        [Route("file-download3")]
        public IActionResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"D:\Cesar\Udemy\Projects&examples\multimedia\docs.pdf"); // to fetch from the database
            //Better this way
            return File(bytes, "application/pdf");
            //return new FileContentResult(bytes, "application/pdf");
        }
    }
}
