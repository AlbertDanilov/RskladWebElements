namespace RskladWebElements.Middlewares
{
    public class AuthenticationMiddleware
    {
        readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next) 
        { 
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];

            if (string.Compare(token, "3e839161-bfb5-49a2-97ad-48e2411f767a", true) == 0)
            {
                await next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;
            }
        }
    }
}
