using Platform;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseMiddleware<Population>();

app.UseMiddleware<Capital>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("routing",
    async (context) => {
        await context.Response.WriteAsync("Routed");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal Middleware Reached");
});

app.Run();