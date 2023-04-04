using System.ComponentModel.DataAnnotations;
using System.Reflection;

/*THIS IS THE CLASS FOR A CUSTOM VALIDATOR*/
namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidatorAttribute : ValidationAttribute //the suffix Attribute is recommended, but is optional
    {
        public string OtherPropertyName{ get; set; }

        public DateRangeValidatorAttribute(string otherPropertyName)
        {
            OtherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)  
        {
            if (value != null)
            {
                //get to_date
                DateTime to_date = Convert.ToDateTime(value);

                //get from_date
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName); // Getting the reference of fromdate property // Type represents a class in this case

                if (otherProperty != null)
                {
                    //Since we are getting the values from the object then they need to be converted to the actuial value needed
                    DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance)); // The property is retrieved trough reflection

                    if (from_date > to_date)
                    {
                        //It is better to have all the errors messages, to avoid things
                        return new ValidationResult(ErrorMessage, new string[] { OtherPropertyName, validationContext.MemberName }); //other name holds the currrent date and Membername gets the other date
                        //In order to prevent to display this message twice then I have to add route validation
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return null;
            }
            return null;
        }
    }
}
