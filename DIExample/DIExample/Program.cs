using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); //Adding autofac
builder.Services.AddControllersWithViews();
//builder.Services.Add(new ServiceDescriptor(
//    typeof(ICitiesServices), //-> first argument is the interface to be provided
//    typeof(CitiesService),   //-> Second is the one that should be created everytime the first parameter is called
//    ServiceLifetime.Scoped //-> Service lifetime
//));
//This is the fast and short way to make it 
//builder.Services.AddTransient<ICitiesServices, CitiesService>();
//builder.Services.AddScoped<ICitiesServices, CitiesService>();
//builder.Services.AddSingleton<ICitiesServices, CitiesService>();

/*Autofac version below*/
builder.Host.ConfigureContainer<ContainerBuilder>(ContainerBuilder =>
{
    //ContainerBuilder.RegisterType<CitiesService>().As<ICitiesServices>().InstancePerDependency(); //Add Transient
    ContainerBuilder.RegisterType<CitiesService>().As<ICitiesServices>().InstancePerLifetimeScope(); //Add AddScoped
    //ContainerBuilder.RegisterType<CitiesService>().As<ICitiesServices>().SingleInstance(); //Add Singleton

});
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.Run();
