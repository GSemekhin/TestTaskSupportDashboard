using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TestTaskSupportDashboard.Middlewares
{
    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;

        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Проверяем, есть ли cookie
            if (context.Request.Cookies.TryGetValue(".AspNetCore.Cookies", out var _))
            {
                // Если есть, перенаправляем на /tickets
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/tickets");
                    return;
                }
            }
            else
            {
                // Если нет, перенаправляем на /login
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/login");
                    return;
                }
            }

            await _next(context);
        }
    }

}
