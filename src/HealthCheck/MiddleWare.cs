using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace HealthCheck
{
    public class Middleware
    {
        private readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if(httpContext.Request.Path=="/") {
                httpContext.Response.StatusCode = 201; //Ok
                await httpContext.Response.WriteAsync("Service Up");
                return;
            };
            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);
        }
    }
}
