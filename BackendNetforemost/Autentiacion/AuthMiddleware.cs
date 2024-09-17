namespace BackendNetforemost.Autentiacion
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public AuthMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey(AuthConstantes.ApiKeyHeaderName))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("ApiKey is missing");
                return;
            }

            var apiKey = context.Request.Headers[AuthConstantes.ApiKeyHeaderName];
            var validApiKey = _configuration.GetValue<string>(AuthConstantes.ApiKey);

            if (!apiKey.Equals(validApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}
