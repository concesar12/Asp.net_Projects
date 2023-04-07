using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{ //This is a class to be used to be passed as parameter
    public class Book
    {
        //[FromQuery] // this will only pick the value for bookid from the query string
        public int? BookId { get; set; }
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book object - Book id: {BookId}, Author: {Author}"; //Return a string that contains all the property values
        }

    }
}
