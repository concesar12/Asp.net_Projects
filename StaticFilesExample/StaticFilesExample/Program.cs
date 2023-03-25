using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions() // This new web appllication is use to configure custom webroot folder
{
    WebRootPath = "myroot"
});
var app = builder.Build();

//This must be on top always
app.UseStaticFiles(); //works with (myroot)
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        //builder.Environment.ContentRootPath + "\\mywebroot" this is one way to concatenate, but above is the prefered way
        Path.Combine(builder.Environment.ContentRootPath, "mywebroot")
        )
}); //works with mywebroot

//app.MapGet("/", () => "Hello World!"); This is't the prefered way instead do next :

//This is the preffered way to start the middlewares
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("/", async context =>
    {
        await context.Response.WriteAsync("Hello");
    });
});

app.Run();
