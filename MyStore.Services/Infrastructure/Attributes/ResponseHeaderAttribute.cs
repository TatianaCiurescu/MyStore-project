using Microsoft.AspNetCore.Mvc.Filters;

namespace MyStore.Services.Infrastructure.Attributes
{
    public class ResponseHeaderAttribute: ActionFilterAttribute
    {
        private readonly string name;
        private readonly string value;

        public ResponseHeaderAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add(name, value);
            base.OnResultExecuting(context);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //query string- decode parameter
            base.OnActionExecuting(context);
        }
    }
}
