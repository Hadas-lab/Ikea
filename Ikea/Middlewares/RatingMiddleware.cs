﻿using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.AspNetCore.Http;
using Services;
using System.Threading.Tasks;

namespace Ikea.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {
            Rating rating = new()
            {
                Host = httpContext.Request.Host.Host,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers["Referer"].ToString(),
                UserAgent = httpContext.Request.Headers["User-Agent"].ToString(),
                RecordDate = DateTime.Now
            };
            await ratingService.AddRating(rating);
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
