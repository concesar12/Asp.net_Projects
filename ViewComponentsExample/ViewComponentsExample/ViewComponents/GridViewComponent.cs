using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.ViewComponents
{
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() // This method is mandatory for every view component
        {
            return View(); //Invoked a partial view Views/Shared/Components/Grid/Default.cshtml tis is the prefered route
        }
    }
}
