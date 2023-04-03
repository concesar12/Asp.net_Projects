﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person
    {
        [Required(ErrorMessage = "{0} can't be empty or null")] // {0} means it will take as an argument the name of the attribute
        [Display(Name = "Person Name")] // This is used to display the name as wanted
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")] // this is used to specify the length 1= 40, 2 = 3 from the values
        [RegularExpression("^[A-Za-z .]$", ErrorMessage = "{0} should contain only alphabets space and a dot")] // This is to accept names with only letters
        public string? PersonName { get; set; }
        [EmailAddress(ErrorMessage = "{0} should be a normal email address example@example.com")]
        [Required(ErrorMessage = "{0} is mandatory")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "{0} should be a phone number")]
        //[ValidateNever] // When this is used then the property will not be validated
        public string? Phone { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        [Compare("Password", ErrorMessage = "{0} and {1} do not match")]
        [Display(Name = "Re-enter Password")]
        public string? ConfirmPassword { get; set; }

        [Range(0, 999.99, ErrorMessage = "{0} should be between {1} and ${2}")] // This evaluates the range
        public double? Price { get; set; }


        [MinimumYearValidator(2005, ErrorMessage = "Date of Birth should not be newer than Jan 01, {0}")]
        //[MinimumYearValidator(2005)] //If this is used then it will take the defaul message created in the class validator
        public DateTime? DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Person object - Person name: {PersonName}, Email: {Email}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Price: {Price}";
        }
    }
}
