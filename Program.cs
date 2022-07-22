using Platform;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Logger.LogDebug("Pipeline configuration starting");

app.MapGet("population/{city?}", Population.Endpoint);

app.Logger.LogDebug("Pipeline configuration complete");

app.Run();