using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Utilities.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BaseDomainException ex)
        {
            _logger.LogWarning(ex, "Domain error occurred.");
            await HandleExceptionAsync(context, ex, HttpStatusCode.BadRequest);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled error occurred.");
            await HandleExceptionAsync(context, ex, HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex, HttpStatusCode statusCode)
    {
        var result = JsonSerializer.Serialize(new
        {
            error = ex.Message,
            correlationId = context.TraceIdentifier
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;
        return context.Response.WriteAsync(result);
    }
}
