using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers // NameOfPrject.Folder
{

    public class HomeController // It is ncessary to suffix the wordcontroller for the class to be taken as a controller // Class must be public to be instantiated by .netcore
    {
        [Route("Hello")] //It is required to define an attribute to specify the route // This is called attribute routing //
        public string method1() // Method to be accessed
        {
            return "Hello from method1"; 
        }
    }
}
