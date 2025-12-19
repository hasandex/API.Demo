# ASP.NET Core Web API - Filter Implementation Example

## Description

This project demonstrates the implementation of various filter types in an ASP.NET Core Web API. It includes a single endpoint with all filter types applied to showcase how they can be used to manage cross-cutting concerns such as logging, authorization, validation, and exception handling. [[1]](https://dotnettutorials.net/lesson/filters-in-asp-net-core-web-api/)[[2]](https://codewithmukesh.com/blog/filters-in-aspnet-core/)

## Features

*   Implementation of Resource Filters
*   Implementation of Action Filters
*   Implementation of Exception Filters
*   Implementation of Result Filters
*   Clear and concise examples of how to apply filters to a single endpoint.
*   Demonstrates the filter execution order in ASP.NET Core.

## Tech Stack

*   .NET Core 8.0
*   ASP.NET Core Web API
*   C#

## Prerequisites

*   .NET Core SDK (8.0) installed on your machine.
*   Visual Studio or Visual Studio Code (optional, but recommended for development).

## Installation

1.  Clone the repository:

    ```bash
    git clone https://github.com/hasandex/API.Demo.git
    ```
2.  Restore the dependencies:

    ```bash
    dotnet restore
    ```
3.  Build the project:

    ```bash
    dotnet build
    ```

## Usage

1.  Run the application:

    ```bash
    dotnet run
    ```
2.  Access the endpoint:

    The API endpoint will be available at `https://localhost:7053/Players`.
3.  Test the filters:

    You can test the different filters by sending requests to the endpoint and observing the behavior, such as:

    *   Validation: Send invalid data to trigger validation filters.
    *   Exception Handling:  Trigger an exception within the endpoint to see the exception filter in action.

## Filter Implementation Details

### 1. Resource Filter

*   **Purpose:** To perform actions around the entire request processing pipeline.
*   **Implementation:** (Provide a code snippet or explanation).
*   **Example:**

    ```csharp
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
    ```

### 2. Action Filter

*   **Purpose:** To execute logic before and after an action executes.
*   **Implementation:** (Provide a code snippet or explanation).
*   **Example:**

    ```csharp
   [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
 public class LogActionFilter : ActionFilterAttribute
 {
     private readonly ILogger<LogActionFilter> _logger;

     public LogActionFilter(ILogger<LogActionFilter> logger)
     {
         _logger = logger;
     }

     public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
     {
         _logger.LogInformation("Attribute filter before");
         await next();
         _logger.LogInformation("Attribute filter after");
     }
 }
    ```

### 3. Exception Filter

*   **Purpose:** To handle unhandled exceptions thrown during the execution of the action.
*   **Implementation:** (Provide a code snippet or explanation).
*   **Example:**

    ```csharp
   public class HandleExceptionFilter : IAsyncExceptionFilter
 {
     public Task OnExceptionAsync(ExceptionContext context)
     {
         var problemDetails = new ProblemDetails()
         {
             Title = "Internal Server Error",
             Status = StatusCodes.Status500InternalServerError,
             Detail = context.Exception.Message
         };
         context.Result = new ObjectResult(problemDetails)
         {
             StatusCode = problemDetails.Status
         };
         context.ExceptionHandled = true;
         return Task.CompletedTask;
     }
 }
    ```

### 4. Result Filter

*   **Purpose:** To execute logic before and after the execution of the action result.
*   **Implementation:** (Provide a code snippet or explanation).
*   **Example:**

    ```csharp
    public class UnifiedResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if(context.Result is ObjectResult objectResult && objectResult != null)
        {
            var wrapped = new
            {
                success = true,
                data = objectResult.Value
            };
            context.Result = new JsonResult(wrapped)
            {
                StatusCode = objectResult.StatusCode
            };
        }
       await next();
    }
}
    ```

## Contributing

1.  Fork the repository.
2.  Create a new branch for your feature or bug fix.
3.  Commit your changes.
4.  Push to the branch.
5.  Submit a pull request.

## License

[Specify the license under which your project is released (e.g., MIT License)](LICENSE)
