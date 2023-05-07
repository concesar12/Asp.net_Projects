using System;
using System.Collections.Generic;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Xunit;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        //Constructor 
        public CountriesServiceTest()
        {
            _countriesService = new CountriesService();
        }

        #region AddCountry
        //When CountryAddRequest is null, it should ArgumentNullException
        [Fact]
        public void AddCountry_NullCountry()
        {
            //arrange
            CountryAddRequest? request = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });

        }

        //When the CountryName is null, it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsNull()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null};

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
            });

        }

        //When the CountryName is duplicate, then it should throw ArgumentException
        [Fact]
        public void AddCountry_CountryNameIsDuplicated()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Colombia" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "Colombia   " };

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                _countriesService.AddCountry(request);
                _countriesService.AddCountry(request2);

            });

        }
        //When you supply proper country name, it should insert (add) the country to the existing list of countries
        [Fact]
        public void AddCountry_CountryNameIsValid()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Colombia" }; ;

            //Act
            CountryResponse response = _countriesService.AddCountry(request);
            List<CountryResponse> countryResponses = _countriesService.GetAllCountries();

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, countryResponses);

        }
        #endregion

        #region GetAllCountries
        [Fact]
        //The list of countries should be empty by default (before adding any countries)
        public void GetAllCountries_EmptyList()
        {
            //Act
            List<CountryResponse> actual_country_response_list = _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(actual_country_response_list);
        }

        [Fact]
        public void GetAllCountries_AddFewCountries()
        {
            //Arrange
            List<CountryAddRequest> country_request_list = new List<CountryAddRequest>() {
            new CountryAddRequest() { CountryName = "USA" },
            new CountryAddRequest() { CountryName = "UK" }
            };

            //Act
            List<CountryResponse> countries_list_from_add_country = new List<CountryResponse>();

            foreach (CountryAddRequest country_request in country_request_list)
            {
                countries_list_from_add_country.Add(_countriesService.AddCountry(country_request));
            }

            List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();

            //read each element from countries_list_from_add_country
            foreach (CountryResponse expected_country in countries_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }
        #endregion


    }
}
