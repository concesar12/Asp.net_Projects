using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() // This method is mandatory for every view component
        {
            PersonGridModel model = new PersonGridModel()
            {
                GridTitle = "PersonsList",
                Persons = new List<Person>()
                {
                    new Person() { PersonName = "John", JobTitle = "Manager"},
                    new Person() { PersonName = "Cesar", JobTitle = "CEO"},
                    new Person() { PersonName = "Lis", JobTitle = "Receptionist"},

                }

            };
            ViewData["Grid"] = model;
            return View(); //Invoked a partial view Views/Shared/Components/Grid/Default.cshtml tis is the prefered route
        }
    }
}
