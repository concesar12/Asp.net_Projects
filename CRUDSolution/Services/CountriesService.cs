using Entities;
using Microsoft.EntityFrameworkCore;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {

        //private field
        private readonly PersonsDbContext _db;

        //constructor
        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }


        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
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
            if (await _db.Countries.CountAsync(tempCountry => tempCountry.CountryName.Trim()
                    == countryAddRequest.CountryName.Trim()) > 0)
            {
                throw new ArgumentException($"Given country name {countryAddRequest.CountryName} already exists");
            }
            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //Generate a new GUID countryID 
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _db.Countries.Add(country);
            await _db.SaveChangesAsync();
            return country.ToCountryResponse();
        }
        
        //Convert all countries from "Country" type to "CountryResponse" type
        //Return all CountryResponse objects
        public async Task<List<CountryResponse>> GetAllCountries()
        {
            return await _db.Countries.Select(country => country.ToCountryResponse()).ToListAsync();
        }

        public async Task<CountryResponse?> GetCountryByCountryID(Guid? countryID)
        {
            //Check if "countryID" is not null
            //Get matching country from List<Country> based countryID
            //Convert matching country object from "Country" to "CountryResponse" type.
            //Return Country Response object
            if (countryID == null) return null;

            Country? country_response_from_list = await _db.Countries.FirstOrDefaultAsync(temp => temp.CountryID == countryID);

            if (country_response_from_list == null) return null;

            return country_response_from_list.ToCountryResponse();
        }
    }
}