using Infrastructure.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    // todo 26 -> Dependency Injection'ları (Resolvers - Çözümleyiciler) tanımladığımız yer.
    public static class ServiceCollectionExtensions
    {
        // todo 27-> ICoreModule'deki modulleri okuyarak bunları ServiceCollections'a yüklüyor. Sonra Bu ServiceCollection'u kullanarak ServiceProvider'ı Create Ediyoruz. Sonra Bu ServiceTool Üzerinden singleton modüllere ulaşıyoruz.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);
        }
    }
}
