using RoutingExample.CustomConstraints;

var builder = WebApplication.CreateBuilder(args);
//Necesary to add the builder
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraint));
});


var app = builder.Build();

//Enable routing
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? file = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In Files {file} - {extension}");
    });
    endpoints.Map("employee/profile/{personName:length(2,8)?}", async context =>
    {
        if(context.Request.RouteValues.ContainsKey("personName"))
        { 
            string? person = Convert.ToString(context.Request.RouteValues["personName"]);
            await context.Response.WriteAsync($"The name of the person is {person}");
        }
        else
        {
            await context.Response.WriteAsync("The person id was not provided");
        }
    });

    endpoints.Map("products/type/{id:int?}", async context =>
    {
        if(context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt16(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"The name of the person is {id}");
        }
        else
        {
            await context.Response.WriteAsync("The ID was not provided");
        }
    });

    endpoints.Map("daily-digest-report/{reportdate:datetime?}", async context =>
    {
        DateTime reportDate = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"In daily-digest-report - {reportDate.ToShortDateString()}");
    });
    //cities/cityid
    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City Id is the next one {cityId}");
    });

    //sales-report/2023/apr
    endpoints.Map("sales-report/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"sales report aer {year} {month}");
    });

    //sales-report/2024/jan
    //This one is prefered route since it is more specific
    endpoints.Map("sales-report/2024/jan", async context =>
    {
        await context.Response.WriteAsync("Sales reports exclusively for 2024 january");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Not route matching: {context.Request.Path}");
});

app.Run();
