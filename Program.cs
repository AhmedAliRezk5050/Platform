var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(opts =>
{
    opts.IdleTimeout = TimeSpan.FromMinutes(30);
    opts.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseSession();

app.UseMiddleware<Platform.ConsentMiddleware>();

app.MapFallback(async context =>
await context.Response.WriteAsync("Hello World!"));

app.Run();