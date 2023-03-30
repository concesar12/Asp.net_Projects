var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(); // This method AddControllers will get all the classes with the suffix controller to add them
//builder.Services.AddTransient<HomeController>(); // This is used for smaller projects
// Above the builder.build is a good place to create any service method
var app = builder.Build();
app.UseStaticFiles(); // thi is necessary to send file as response
/*THIS IS THE LONG WAY TO DO IT*/
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers(); // This will map all the controllers found in the project
//});
/*INSTEAD THE MAP CONTROLLER METHOS DOES EVERYTHING DONE ABOVE*/
app.MapControllers();
app.Run();
