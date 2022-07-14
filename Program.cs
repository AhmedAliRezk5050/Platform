using Platform;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("{f}/{s}/{t}", async context =>
{
    await context.Response.WriteAsync("Request Was Routed\n");

    foreach (var item in context.Request.RouteValues)
    {
        await context.Response.WriteAsync($"{item.Key} - {item.Value}\n");
    }
});

app.MapGet("capital/{country}", Capital.Endpoint);

app.MapGet("size/{city}", Population.Endpoint)
    .WithMetadata(new RouteNameMetadata("population")); ;

app.Run();