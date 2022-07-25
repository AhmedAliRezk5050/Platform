var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache(opts =>
{
    opts.SizeLimit = 200;
});

var app = builder.Build();

app.MapEndpoint<Platform.SumEndpoint>("/sum/{count:int=1000000000}");

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World!");
});

app.Run();