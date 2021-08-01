using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Tokenizer.Api.Helpers;
using Tokenizer.Domain.SeedWork;

namespace Tokenizer.Api.Middleware
{
    public class GlobalErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is Item_Not_FoundException || ex is Item_ExistException )
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                else
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(new ErrorDetails()
                {
                    StatusCode = context.Response.StatusCode,
                    Message = $"Message: {ex.Message}",
                    ErrorType = ex.GetType().ToString()
                }.ToString());
            }
        }
    }
}
