using System;
using System.Collections.Generic;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using Services;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EntityFrameworkCoreMock;
using Moq;

namespace CRUDTests
{
    public class CountriesServiceTest
    {
        private readonly ICountriesService _countriesService;

        //Constructor 
        public CountriesServiceTest()
        {
            var countriesInitialData = new List<Country>() { };

            DbContextMock<ApplicationDbContext> dbContextMock = new DbContextMock<ApplicationDbContext>(
              new DbContextOptionsBuilder<ApplicationDbContext>().Options // This will create the db context options
             );

            ApplicationDbContext dbContext = dbContextMock.Object;
            dbContextMock.CreateDbSetMock(temp => temp.Countries, countriesInitialData); //Retrieve the dbsets for persons and countries

            _countriesService = new CountriesService(dbContext);
        }

        #region AddCountry
        //When CountryAddRequest is null, it should ArgumentNullException
        [Fact]
        public async Task AddCountry_NullCountry()
        {
            //arrange
            CountryAddRequest? request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _countriesService.AddCountry(request);
            });

        }

        //When the CountryName is null, it should throw ArgumentException
        [Fact]
        public async Task AddCountry_CountryNameIsNull()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null};

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _countriesService.AddCountry(request);
            });

        }

        //When the CountryName is duplicate, then it should throw ArgumentException
        [Fact]
        public async Task AddCountry_CountryNameIsDuplicated()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Colombia" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "Colombia   " };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _countriesService.AddCountry(request);
                await _countriesService.AddCountry(request2);

            });

        }
        //When you supply proper country name, it should insert (add) the country to the existing list of countries
        [Fact]
        public async Task AddCountry_CountryNameIsValid()
        {
            //arrange
            CountryAddRequest? request = new CountryAddRequest() { CountryName = "Colombia" }; ;

            //Act
            CountryResponse response = await _countriesService.AddCountry(request);
            List<CountryResponse> countryResponses = await _countriesService.GetAllCountries();

            //Assert
            Assert.True(response.CountryId != Guid.Empty);
            Assert.Contains(response, countryResponses);

        }
        #endregion

        #region GetAllCountries
        [Fact]
        //The list of countries should be empty by default (before adding any countries)
        public async Task GetAllCountries_EmptyList()
        {
            //Act
            List<CountryResponse> actual_country_response_list = await _countriesService.GetAllCountries();

            //Assert
            Assert.Empty(actual_country_response_list);
        }

        [Fact]
        public async Task GetAllCountries_AddFewCountries()
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
                countries_list_from_add_country.Add(await _countriesService.AddCountry(country_request));
            }

            List<CountryResponse> actualCountryResponseList = await _countriesService.GetAllCountries();

            //read each element from countries_list_from_add_country
            foreach (CountryResponse expected_country in countries_list_from_add_country)
            {
                Assert.Contains(expected_country, actualCountryResponseList);
            }
        }
        #endregion

        #region GetCountryByCountryID

        [Fact]
        //If we supply null as CountryID, it should return null as CountryResponse
        public async Task GetCountryByCountryID_NullCountryID()
        {
            //Arrange
            Guid? countrID = null;

            //Act
            CountryResponse? country_response_from_get_method = await _countriesService.GetCountryByCountryID(countrID);


            //Assert
            Assert.Null(country_response_from_get_method);
        }


        [Fact]
        //If we supply a valid country id, it should return the matching country details as CountryResponse object
        public async Task GetCountryByCountryID_ValidCountryID()
        {
            //Arrange
            CountryAddRequest? country_add_request = new CountryAddRequest() { CountryName = "China" };
            CountryResponse country_response_from_add = await _countriesService.AddCountry(country_add_request);

            //Act
            CountryResponse? country_response_from_get = await _countriesService.GetCountryByCountryID(country_response_from_add.CountryId);

            //Assert
            Assert.Equal(country_response_from_add, country_response_from_get);
        }
        #endregion
    }
}
