using System;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utilities.IoC
{
    // todo 14-> IoC için Dependency Injection'ları Yükleyecek Interface oluşturuyoruz. IServiceCollection için Microsoft.Extensions.DependencyInjection Library'sini kullanıyoruz.
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
