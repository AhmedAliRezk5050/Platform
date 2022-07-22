using Platform;
using Platform.Services;


var builder = WebApplication.CreateBuilder(args);

IConfiguration config = builder.Configuration;

builder.Services.AddScoped<IResponseFormatter>(serviceProvider => {
    string? typeName = config["services:IResponseFormatter"];
    return (IResponseFormatter)ActivatorUtilities
    .CreateInstance(serviceProvider, typeName == null
    ? typeof(GuidService) : Type.GetType(typeName, true)!);
});

builder.Services.AddScoped<ITimeStamper, DefaultTimeStamper>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

app.MapGet("middleware/function", 
            async (HttpContext context,
                   IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
});

//app.MapEndpoint<WeatherEndpoint>("endpoint/class");


app.MapGet("endpoint/function", async (HttpContext context) =>
{
    IResponseFormatter formatter =
    context.RequestServices.GetRequiredService<IResponseFormatter>();
    await formatter.Format(context, "Endpoint Function: It is sunny in LA");
});

app.Run();