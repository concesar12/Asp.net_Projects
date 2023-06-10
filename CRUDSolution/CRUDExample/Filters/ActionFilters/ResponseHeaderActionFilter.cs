using Microsoft.AspNetCore.Mvc.Filters;

namespace CRUDExample.Filters.ActionFilters
{
    public class ResponseHeaderActionFilter : IActionFilter, IOrderedFilter
    {
        //Creating logger
        private readonly ILogger<ResponseHeaderActionFilter> _logger;
        //Response header key
        private readonly string Key;
        //Response header value
        private readonly string Value;
        //This comes with IOrderedFilter after implemet interface
        public int Order { get; }

        //Constructor initialize variables
        public ResponseHeaderActionFilter(ILogger<ResponseHeaderActionFilter> logger, string key, string value, int order)
        {
            _logger = logger;
            Key = key;
            Value = value;
            Order = order;
        }


        //before
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("{FilterName}.{MethodName} method", nameof(ResponseHeaderActionFilter), nameof(OnActionExecuting));
        }

        //after
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("{FilterName}.{MethodName} method", nameof(ResponseHeaderActionFilter), nameof(OnActionExecuted));
            //Contexts will allow to access to the request, response and session object
            context.HttpContext.Response.Headers[Key] = Value;
        }
    }
}
