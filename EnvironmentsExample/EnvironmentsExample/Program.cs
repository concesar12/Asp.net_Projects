var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging()) // This returns true is if is development environment
{
    app.UseDeveloperExceptionPage(); // Thi sis for the exception
}
app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();
