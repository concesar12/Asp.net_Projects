var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => //The rihght way to read this is by, whenever going to this endpoint perform whatever is inside of the lamda function
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync(app.Configuration["MyKey"] + "\n"); //this is not case sensitive
        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey") + "\n"); //this is not case sensitive
        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n"); // In this case x will be taken from the configuration but if not present 10 will be taken as default
    });
});

app.MapControllers();
app.Run();
