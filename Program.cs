using Microsoft.Extensions.Options;

using Platform;



var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MessageOptions>(options =>
{
    options.CityName = "Albany";
});


var app = builder.Build();

app.MapGet("/location", async (HttpContext context,
                                IOptions<MessageOptions> msgOpts) =>
{
    MessageOptions opts = msgOpts.Value;

    await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
});


//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});

app.MapGet("/", () => "Hello World!");

app.Run();