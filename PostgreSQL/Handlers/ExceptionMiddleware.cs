using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PostgreSQL.Handlers
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _log;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> log)
        {
            _next = next;
            _log = log;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await RespondAsync(context, (int) HttpStatusCode.Forbidden, ex.Message);
            }
            catch (ArgumentException ex)
            {
                _log.LogError(ex, "Invalid request. {Error}", ex.Message);
                await RespondAsync(context, (int) HttpStatusCode.BadRequest, ex.Message);
            }
            catch (OperationCanceledException ex)
            {
                _log.LogError(ex, "Request cancelled or timed out. {Error}", ex.Message);
                await RespondAsync(context, 408, ex.Message);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Exception encountered handling request. {Error}", ex.Message);
                await RespondAsync(context, 500, ex.Message);
            }
        }

        private static Task RespondAsync(HttpContext context, int statusCode, string errorMessage)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync(errorMessage);
        }
    }
}
