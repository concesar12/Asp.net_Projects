using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidatorAttribute : ValidationAttribute // In order to behave as a validator this needs to be inherit
    {
        public int MinimumYear { get; set; } = 2000;
        public string DefaultErrorMessage { get; set; } = "Year should not be less than {0}"; 
        //Parameterless contructor 
        public MinimumYearValidatorAttribute()
        {
        }
        public MinimumYearValidatorAttribute(int minimumYear)
        {
            MinimumYear = minimumYear;
        }
        //This was created by overriding and clicking last option
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;
                if (date.Year >= MinimumYear)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYear)); // pass this error message since is the the predefine 
                } // The statement above ?? cheack if the value is null and if it is it takes the second attribute
                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }
    }
}
