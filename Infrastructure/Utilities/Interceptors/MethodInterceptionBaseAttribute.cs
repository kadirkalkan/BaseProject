using Castle.DynamicProxy;
using System;

namespace Infrastructure.Utilities.Interceptors
{
    // todo 9-> IInterceptor'ları Attribute olarak kullanmak için Burayı tanımladık, Castle.Core Library'sini kullandı. Autofac'de aynı altyapıyı kullanıyor.
    // todo 10-> Nerelerde Attribute olarak kullanılabileceğine dair tanımlama yaptık. Hem Exception Hem Log'lama aynı Attribute'u kullanacağından birden fazla kullanıma izin vermemiz gerekiyor.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
            
        }
    }
}