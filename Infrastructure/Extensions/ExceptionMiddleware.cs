using FluentValidation;
using Infrastructure.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    // todo 19-> Bütün Exceptionları Yakalayacak Middleware mekanizması.
    public class ExceptionMiddleware
    {
        // todo 20-> Microsoft.AspNetCore.Http.Abstractions Library'si kullanılıyor.
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        // todo 21-> Method'u Invoke edip Hata kontrolü yapıyor.
        public async Task InvokeAsync(HttpContext httpContext) {
            try
            {
                // todo 21.1 Request'i Yakalayıp Run Ediyoruz. Sonucuna göre yönetebilelim diye.
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        
        }

        // todo 22-> Yakalanan Hatayı Çözümleyip Geri Response Dönderiyoruz.
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            string message = MiddlewareMessages.InternalServerError;
            // todo 23-> ValidationException Class'ı FluentValidation Library'sini kullanıyor.
            // ValidationException implementeEdilen bir yapı ve Gelen message'ın içeriğini custom olarak farklı exception türlerine göre değiştirmemiz için bize esneklik sağlıyor.
            if (exception.GetType() == typeof(ValidationException))
            {
                message = exception.Message;
            }
            // todo 24-> Hata Mesajı alındıktan sonra Geriye Oluşturduğumuz ErrorDetails Objesini Dönderiyoruz. WriteAsync() String Aldığından Objeyi Serialize Ediyoruz.
            return httpContext.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
