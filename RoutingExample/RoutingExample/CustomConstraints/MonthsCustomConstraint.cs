using System.Text.RegularExpressions;

namespace RoutingExample.CustomConstraints
{
    public class MonthsCustomConstraint : IRouteConstraint
    {
        /*httpContext - Context received in the middleware Request/Response
         *route - object that represents the route
         values - name of the parameter
        *routeDirection - one or more values received from the incomming request*/
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //Check whether the value exists
            if(!values.ContainsKey(routeKey)) // Could be month
            {
                return false;
            }

            Regex regex = new Regex("^(apr|jun|jul|oct|jan)$");
            string? monthValue = Convert.ToString(values[routeKey]);

            if (regex.IsMatch(monthValue))
            {
                return true;
            }
            return false;
        }
    }
}
