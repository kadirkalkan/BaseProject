using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    // todo 25-> Middleware Olarak Yazdığımız Custom ExceptionMiddleware'i tanımlıyoruz. IApplicationBuilder Interface'i Microsoft.AspNetCore.Builder Library'sinden Geliyor.
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionsMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
