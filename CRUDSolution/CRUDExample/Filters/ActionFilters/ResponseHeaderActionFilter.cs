using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ActionFilters
{
    public class ResponseHeaderActionFilter : ActionFilterAttribute
    {
        //Creating logger
        //private readonly ILogger<ResponseHeaderActionFilter> _logger; // We can't inject logger because ActionFilterAttribute does not allow
        //Response header key
        private readonly string _key;
        //Response header value
        private readonly string _value;
        //This comes with IOrderedFilter after implemet interface
        //public int Order { get; } //This is precreated by ActionFilterAttribute

        //Constructor initialize variables
        public ResponseHeaderActionFilter(string key, string value, int order)
        {
            //_logger = logger; no longer supported by actionfilter
            _key = key;
            _value = value;
            Order = order;
        }

        /*This piece is not longer necessary as we are using an async filter*/
        ////before
        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    _logger.LogInformation("{FilterName}.{MethodName} method", nameof(ResponseHeaderActionFilter), nameof(OnActionExecuting));
        //}

        ////after
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    _logger.LogInformation("{FilterName}.{MethodName} method", nameof(ResponseHeaderActionFilter), nameof(OnActionExecuted));
        //    //Contexts will allow to access to the request, response and session object
        //    context.HttpContext.Response.Headers[_key] = _value;
        //}

        //Now we can use async in here //This will handle both previous
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //_logger.LogInformation("{FilterName}.{MethodName} method - before", nameof(ResponseHeaderActionFilter), nameof(OnActionExecutionAsync));

            await next(); //calls the subsequent filter or action method It is necessary to go to after

            //_logger.LogInformation("{FilterName}.{MethodName} method - after", nameof(ResponseHeaderActionFilter), nameof(OnActionExecutionAsync));

            context.HttpContext.Response.Headers[_key] = _value;
        }
    }
}
