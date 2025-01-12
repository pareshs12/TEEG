namespace TestGuestApp.API.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeader = "X-Api-Key";
        private const string ApiKey = "test-guest-api-key";

        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey(ApiKeyHeader) ||
                context.Request.Headers[ApiKeyHeader] != ApiKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized request.");
                return;
            }

            await _next(context);
        }
    }
}
