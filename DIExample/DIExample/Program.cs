using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(
    typeof(ICitiesServices), //-> first argument is the interface to be provided
    typeof(CitiesService),   //-> Second is the one that should be created everytime the first parameter is called
    ServiceLifetime.Transient //-> Service lifetime
));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
