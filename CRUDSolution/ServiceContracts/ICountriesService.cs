﻿using Microsoft.AspNetCore.Http;
using ServiceContracts.DTO;

namespace ServiceContracts
{
    /// <summary>
    /// Represents business logic for manipulating Country entity
    /// </summary>
    public interface ICountriesService
    {
        /// <summary>
        /// Adds a country object to the list of countries
        /// </summary>
        /// <param name="countryAddRequest">Country object to add</param>
        /// <returns>returns the country object after ading it (including newly generated country id)</returns>
        Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest);

        /// <summary>
        /// Returns all countries from the list
        /// </summary>
        /// <returns>All countries from the list as List of CountryResponse</CountryResponse></returns>
        Task<List<CountryResponse>> GetAllCountries();

        /// <summary>
        /// Returns a country object based on the given country ID
        /// </summary>
        /// <param name="countryID">Country ID (guid) to search</param>
        /// <returns>Matching country as CountryResponse object</returns>
        Task<CountryResponse?> GetCountryByCountryID(Guid? countryID);

        //Task UploadCountriesFromExcelFile(IEnumerable<IFormFile> formFile); In case wanting to have the chance to upload 1+ file

        /// <summary>
        /// Uploads countries from excel file into database
        /// </summary>
        /// <param name="formFile">Excel file with list of countries</param>
        /// <returns>Returns number of countries</returns>
        Task<int> UploadCountriesFromExcelFile(IFormFile formFile);
    }
}