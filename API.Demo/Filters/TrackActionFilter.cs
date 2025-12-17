using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Demo.Filters
{
    public class TrackActionFilter : IAsyncActionFilter
    {
        private readonly ILogger<TrackActionFilter> _logger;
        public TrackActionFilter(ILogger<TrackActionFilter> logger)
        {
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation("start before");
            await next();
            _logger.LogInformation("start after");
        }
    }
}
