﻿using CRUDExample.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts.DTO;
using ServiceContracts;

namespace CRUDExample.Filters.ActionFilters
{
    //Using Async since we are calling an async filter
    public class PersonCreateAndEditPostActionFilter : IAsyncActionFilter
    {
        //add countries services
        private readonly ICountriesService _countriesService;

        //Add logging for the impact of short circuiting
        private readonly ILogger<PersonCreateAndEditPostActionFilter> _logger;

        public PersonCreateAndEditPostActionFilter(ICountriesService countriesService, ILogger<PersonCreateAndEditPostActionFilter> logger)
        {

            _countriesService = countriesService;
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //TO DO: before logic
            //necessary to access the modeal state
            if (context.Controller is PersonsController personsController)
            {
                if (!personsController.ModelState.IsValid)
                {
                    List<CountryResponse> countries = await _countriesService.GetAllCountries();
                    personsController.ViewBag.Countries = countries.Select(temp =>
                    new SelectListItem() { Text = temp.CountryName, Value = temp.CountryId.ToString() });

                    personsController.ViewBag.Errors = personsController.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    //Receiving parameter value
                    var personRequest = context.ActionArguments["personRequest"];

                    context.Result = personsController.View(personRequest); //short-circuits or skips the subsequent action filters & action method
                }
                else
                {
                    await next(); //invokes the subsequent filter or action method
                }
            }
            else
            {
                await next(); //calls the subsequent filter or action method
            }

            //TO DO: After logic
            _logger.LogInformation("In after logic of PersonsCreateAndEdit Action filter");
        }
    }
}
