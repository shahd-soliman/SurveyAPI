namespace Survey.app.Middlewares
{
    public class CustomMiddleware
    {
        private readonly ILogger<CustomMiddleware> _logger;
        private readonly RequestDelegate _next;
        public CustomMiddleware(ILogger<CustomMiddleware> logger , RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task  InvokeAsync (HttpContext context)
        {
             _logger.LogInformation(message:"Request processing..");
           await  _next(context);
            _logger.LogInformation(message: "Response Processing..");
        }

    }

    public static class LoggerMiddleWare
    {
        public static IApplicationBuilder UseLoggerMiddleWare(this IApplicationBuilder app)
        {

            return
                app.UseMiddleware<CustomMiddleware>();
        }
    }
}

