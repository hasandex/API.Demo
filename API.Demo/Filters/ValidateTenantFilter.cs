using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Demo.Filters
{
    public class ValidateTenantFilter(IConfiguration configuration) : IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            var tenantId = context.HttpContext.Request.Headers["TenantId"].ToString();
            var apiKey = context.HttpContext.Request.Headers["ApiKey"].ToString();
            var expectedTenant = configuration[$"Tenants:{tenantId}:apiKey"];
            if(string.IsNullOrWhiteSpace(apiKey) || expectedTenant != apiKey)
            {
                context.Result = new ForbidResult();
                return;
            }
            await next();
        }
    }
}
