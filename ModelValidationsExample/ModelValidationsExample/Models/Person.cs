using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can't be empty or null")] // {0} means it will take as an argument the name of the attribute
        [Display(Name = "Person Name")] // This is used to display the name as wanted
        [StringLength(40, MinimumLength =3, ErrorMessage = "{0} should be between {2} and {1} characters long")] // this is used to specify the length 1= 40, 2 = 3 from the values
        public string? PersonName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        [Range(0, 999.99, ErrorMessage = "{0} should be between {1} and ${2}")] // This evaluates the range
        public double? Price { get; set; }

        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }
}
