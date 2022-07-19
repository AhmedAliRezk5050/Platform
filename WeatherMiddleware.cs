using Platform.Services;

namespace Platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        private IResponseFormatter formatter;

        public WeatherMiddleware(RequestDelegate nextDelegate,
                                IResponseFormatter responseFormatter)
        {
            next = nextDelegate;
            formatter = responseFormatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
            {
                await formatter
                        .Format(context, "Middleware Class: It is raining in London");
            }
            else
            {
                await next(context);
            }
        }
    }
}