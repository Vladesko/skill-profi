using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using FluentValidation;
using Statements.Application.Common.Exceptions;

namespace Statements.WebApi.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                //Maybe dont throw Exception, better is return Exception?
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception) 
            {
                case FluentValidation.ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Errors);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Convert.ToInt32(code);

            if (result == string.Empty)
                result = JsonSerializer.Serialize(new { error = exception.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
