using Platform;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpLogging();

app.MapGet("population/{city?}", Population.Endpoint);

app.Run();