var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapWhen(context => context.Request.Query.Keys.Contains("custom"), branch => {
    branch.UseMiddleware<Platform.QueryStringMiddleWare>();
    branch.Use(async (HttpContext context, Func<Task> next) => {
        await context.Response.WriteAsync($"MapWhen Branched Middleware");
    });
});

app.UseMiddleware<Platform.QueryStringMiddleWare>();

app.MapGet("/", () => "Hello World!");

app.Run();