using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {

        //private field
        private readonly List<Country> _countries;

        //constructor
        public CountriesService()
        {
            _countries = new List<Country>();
        }


        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {

            //Validation: countryAddRequest parameter can't be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: countryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName can't be duplicate
            //TODO Validate the name with a Regex to check Capital letters-numbers or special characters
            if (_countries.Where(tempCountry => tempCountry.CountryName.Trim() == countryAddRequest.CountryName.Trim()).Count() > 0)
            {
                throw new ArgumentException($"Given country name {countryAddRequest.CountryName} already exists");
            }
            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //Generate a new GUID countryID 
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }
        
        //Convert all countries from "Country" type to "CountryResponse" type
        //Return all CountryResponse objects
        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }
    }
}