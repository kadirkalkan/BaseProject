using Infrastructure.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyResolvers
{
    // todo 28-> ICoreModule implement edip, Dependency'leri tanımlıyoruz.
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            // todo 29 -> ExceptionMiddleware için Tanımlamamız Gerekiyor.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // todo 30 -> PerformanceAspect için ekliyoruz. Method'un kaç sn'de çalıştığını ölçüyor.
            services.AddSingleton<Stopwatch>();
        }
    }
}
