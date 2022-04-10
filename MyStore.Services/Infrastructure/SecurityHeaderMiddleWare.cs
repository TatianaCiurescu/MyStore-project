using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyStore.Services.Infrastructure
{
    public class SecurityHeaderMiddleWare
    {
        private readonly RequestDelegate next;
        public SecurityHeaderMiddleWare(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("We", "AreAwesome");
            await this.next.Invoke(httpContext);
        }
    }
}
