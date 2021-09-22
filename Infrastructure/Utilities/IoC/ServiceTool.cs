using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.IoC
{
    // todo 15-> Single Instance üretmek için kullanılan service türü.
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            //todo 16 -> BuildServiceProvider Methodu için Abstraction yerine sade Microsoft.Extensions.DependencyInjection Library'si yüklenmeli.
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
