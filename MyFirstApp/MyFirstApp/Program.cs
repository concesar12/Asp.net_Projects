/*This is a builder created for web aplications in .net environment 
 Builder application loads configuration, environment and services*//*
var builder = WebApplication.CreateBuilder(args);
*//*App in this case is acting as a middleware where the builder is being called*//*
var app = builder.Build();
*//*Whenever is in the local host which is the "/" the response will be the hello world*//*
//int variable = 5 + 87;
//app.MapGet("/", () => variable );
*//*Run method is in charge of starting the server*//*
app.Run(async (HttpContext context) =>
{
    context.Response.StatusCode = 400;
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync("World");

});

app.Run();
*/

/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    context.Response.Headers["Content-type"] = "text/html";
    var contexto = context.Request.Method;
    var QueryMessage = context.Request.Query;
    if (contexto == "GET")
    {
        if (QueryMessage.ContainsKey("id")) // Query strings are available in the variable request.query
        {
            string id = context.Request.Query["id"];
            await context.Response.WriteAsync($"<p>{QueryMessage}</p>");
        }
    }
});

app.Run();*/

//Get and post excercice
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();
});

app.Run();




/*using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader reader = new StreamReader(context.Request.Body);
    string body = await reader.ReadToEndAsync();

    Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

    if (queryDict.ContainsKey("firstName"))
    {
        string firstName = queryDict["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }
});

app.Run();
*/