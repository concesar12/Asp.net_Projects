namespace MiddlewareExample.CustomMiddleware
    
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My custom Middleware - starts");
            await next(context);
            await context.Response.WriteAsync("My custom Middleware - ends");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app) 
        {
           return app.UseMiddleware<MyCustomMiddleware>();
        }
    }
}

