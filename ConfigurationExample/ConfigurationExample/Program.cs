using ConfigurationExample; // Got it for the DI

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
//Supply an object of WeatherApiOptions (with 'weatherapi' section) as a service
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("weatherapi")); // This is done in order to use DI in the configuration
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyOwnConfig.json", optional:true, reloadOnChange: true); 
});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
/* This was used for the IconfigurationController
app.UseEndpoints(endpoints => //The rihght way to read this is by, whenever going to this endpoint perform whatever is inside of the lamda function
{
    endpoints.Map("/config", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyKey"] + "\n"); //this is not case sensitive
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n"); //this is not case sensitive
        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n"); // In this case x will be taken from the configuration but if not present 10 will be taken as default
    });
});
*/
app.MapControllers();
app.Run();
