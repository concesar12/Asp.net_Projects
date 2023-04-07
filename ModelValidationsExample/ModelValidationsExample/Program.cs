using ModelValidationsExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new PersonBinderProvider()); // First argumet means the first object or it means is at the first place or the index and second the model
});
builder.Services.AddControllers().AddXmlSerializerFormatters(); // This is for input formatter, this will allow the controller read xml or json format
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.Run();
