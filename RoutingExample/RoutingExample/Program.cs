var builder = WebApplication.CreateBuilder(args);
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

    endpoints.Map("cities/{cityid:guid}", async context =>
    {
        Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"])!);
        await context.Response.WriteAsync($"City Id is the next one {cityId}");
    });

    endpoints.Map("sales-report/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);

        await context.Response.WriteAsync($"sales report aer {year} {month}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync($"Not route matching: {context.Request.Path}");
});

app.Run();
