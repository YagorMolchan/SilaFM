using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Pras.Shared.Helpers;

namespace Pras.Web.Middleware
{
    public class CheckIP
    {
        private readonly RequestDelegate _next;

        public CheckIP(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Session.Keys.Contains("CountryCode"))
            {
                var ip = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
                IPGeographicalLocation geoLocation = IPGeographicalLocation.QueryGeographicalLocationAsync("95.31.18.119").Result;
                if (!string.IsNullOrEmpty(geoLocation.CountryCode))
                    context.Session.SetString("CountryCode", geoLocation.CountryCode);
            }

            await _next.Invoke(context);

            // Clean up.
        }
    }

    public static class CheckIPExtensions
    {
        public static IApplicationBuilder UseCheckIP(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CheckIP>();
        }
    }
}
