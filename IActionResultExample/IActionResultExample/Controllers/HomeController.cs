using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore")]
        //Url: /bookstore?bookid=5&isloggedin=true
        public IActionResult Index()
        {
            //Book id should be supplied
            if(!Request.Query.ContainsKey("bookid"))
            {
                //Instead of writing all of this:
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
                //And instead of this down:
                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
            }
            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be null or empty");
                return BadRequest("Book id can't be null or empty");

            }
            //Book id should be between 1 to 1000
            int bookid = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]); // this is the best actual way get request
            if(bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be less then or equal to zero");
                return BadRequest("Book id can't be less then or equal to zero");
            }
            if (bookid > 1000)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be greater than 1000");
                return NotFound("Book id can't be greater than 1000"); // this is the way to make 404 not found
            }

            //is logged in should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                //Response.StatusCode = 401;
                //return Content("User must be authenticated");
                //return Unauthorized("Book id can't be greater than 1000");
                return StatusCode(401); // in order to use the status code
            }

            //return new RedirectToActionResult("Books", "Store", new { }); //302 Found
            //There is another way to do this that is: 
            //return RedirectToAction("Books", "Store", new { id=bookid } /*Route parameter*/);
            //Alternatively this can be used: 
            //return new RedirectToActionResult("Books", "Store", new { }, permanent: true); //301 - Moved Permanently // instead of parameter can be only true
            //This is the short way to have it permanentely removed 301
            //return RedirectToActionPermanent("Books", "Store", new { id = bookid });

            //return new LocalRedirectResult($"store/books/{ bookid }"); // Better for internal url
            //There is a shortcut for this
            //return LocalRedirect($"store/books/{ bookid }"); //302 Found by default

            //return new LocalRedirectResult($"store/books/{ bookid }", true); //301 Moved permanentely
            //Shortcut
            return LocalRedirectPermanent($"store/books/{bookid}");




        }
    }
}
