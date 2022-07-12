using Platform;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(new QueryStringMiddleWare().Invoke);

app.Run(async (context) => {
    await context.Response.WriteAsync($"Run Middleware");
});


app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Run();