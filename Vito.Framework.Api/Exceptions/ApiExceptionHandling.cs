using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Vito.Framework.Common.Constants;

namespace Vito.Framework.Api.Exceptions;

public class ApiExceptionHandling(RequestDelegate _next, ILogger<ApiExceptionHandling> _logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        string result;

        if (ex is DomainException e)
        {
            var problemDetails = new CustomValidationProblemDetails(new List<ValidationError> { new() { Code = e.Code, Message = e.Message } })
            {
                Type = FrameworkConstants.ApplicationNamespace,
                Title = "One or more validation errors occurred.",
                Status = (int)HttpStatusCode.BadRequest,
                Instance = context.Request.Path,
            };
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            result = JsonSerializer.Serialize(problemDetails);
        }
        else
        {
            _logger.LogError(ex, $"An unhandled exception has occurred, {ex.Message}");
            var problemDetails = new ProblemDetails
            {
                Type = FrameworkConstants.ApplicationNamespace,
                Title = "Internal Server Error.",
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.Request.Path,
                Detail = ex.Message
            };
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            result = JsonSerializer.Serialize(problemDetails);
        }

        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }
}