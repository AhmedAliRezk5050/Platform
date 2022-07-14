using Platform;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("countryName",
    typeof(CountryRouteConstraint));
});

var app = builder.Build();

app.Map("{number:int}", async context =>
{
    await context.Response.WriteAsync("Routed to the int endpoint");
}).Add(b => ((RouteEndpointBuilder)b).Order = 1);

app.Map("{number:double}", async context =>
{
    await context.Response
    .WriteAsync("Routed to the double endpoint");
}).Add(b => ((RouteEndpointBuilder)b).Order = 2);

app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Routed to fallback endpoint");
});

app.Run();

