using BussinessObject.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;

namespace CartoonFilm_TranThienLoc
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var url = httpContext.Request.GetEncodedUrl().ToLower();
            if (!url.Contains("login"))
            {
                var userString = httpContext.Session.GetString("ACCOUNT");
                if (userString != null)
                {
                    var userConvert = JsonConvert.DeserializeObject<MemberAccount>(userString);
                    if (userConvert != null)
                    {
                        if (userConvert.Role != 3)
                        {
                            httpContext.Response.Redirect("/Login?error=1");
                            return;
                        }
                    }
                }
                else
                {
                    httpContext.Response.Redirect("/Login");
                    return;
                }
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
