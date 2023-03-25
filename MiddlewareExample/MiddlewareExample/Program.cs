using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();
//middlware 1
app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("Hello");
    await next(context); // This context is passed to the next middleware
});

//middlware 2
//app.UseMiddleware<MyCustomMiddleware>();
//app.UseMyCustomMiddleware();
app.UseHelloCustomMiddleware();


app.Run(async (context) => {
    await context.Response.WriteAsync("again");
});
app.Run();
