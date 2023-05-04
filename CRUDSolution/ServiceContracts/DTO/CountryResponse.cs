using System;
using Entities;

namespace ServiceContracts.DTO
{
    /// <summary>
    /// DTO classthat is used as return type for most of CountriesService methods
    /// </summary>
    public class CountryResponse
    {
        public Guid CountryId { get; set; }
        public string? CountryName { get; set; }
    }

    public static class CountryExtensions
    {
        public static CountryResponse ToCountryResponse (this Country country) //This will be received in the entities class
        {
            return new CountryResponse() { CountryId = country.CountryID, CountryName = country.CountryName };
        }
    }
}
