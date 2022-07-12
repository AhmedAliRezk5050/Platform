var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    await next();
    await context.Response
    .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/short")
    {
        await context.Response
        .WriteAsync($"Request Short Circuited");
    }
    else
    {
        await next();
    }
});

app.Use(async (context, next) =>
{
    if (context.Request.Method == HttpMethods.Get
    && context.Request.Query["custom"] == "true")
    {
        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync("lambda function middleware \n");
    }
    await next();
});

app.UseMiddleware<Platform.QueryStringMiddleWare>();

app.Run();


// services are objects that provide features.
// Managed by asp.net core.
// DI makes it easy to access services in the application