using Microsoft.Extensions.Options;
using Platform.Services;

namespace Platform
{
    public class LocationMiddleware
    {
        private RequestDelegate next;

        private readonly MessageOptions messageOptions;

        public LocationMiddleware(RequestDelegate nextDelegate,
            IOptions<MessageOptions> options)
        {
            next = nextDelegate;

            messageOptions = options.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
            {
                await context.Response.WriteAsync($"{messageOptions.CityName}, {messageOptions.CountryName}");
            }
            else
            {
                await next(context);
            }
        }
    }
}