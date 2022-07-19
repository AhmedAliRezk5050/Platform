using Platform;
using Platform.Services;

namespace Microsoft.AspNetCore.Builder
{
    public static class EndpointExtensions
    {
        public static void MapWeather(this IEndpointRouteBuilder app, string path)
        {
            IResponseFormatter formatter = app.ServiceProvider
                                              .GetRequiredService<IResponseFormatter>();

            app.MapGet(path, context => WeatherEndpoint.Endpoint(context, formatter));
        }
    }
}