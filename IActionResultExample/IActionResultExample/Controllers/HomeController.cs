using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("book")]
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

            return File("/sample.pdf", "application/pdf");

        }
    }
}
