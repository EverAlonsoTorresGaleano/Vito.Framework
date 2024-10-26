using Microsoft.AspNetCore.Builder;
using Vito.Framework.Api.Exceptions;

namespace Vito.Framework.Api.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomApiExceptionHandling(this IApplicationBuilder app)
        => app.UseMiddleware<ApiExceptionHandling>();
}