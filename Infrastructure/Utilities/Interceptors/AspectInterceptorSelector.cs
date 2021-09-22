using Castle.DynamicProxy;
using Infrastructure.Aspects.Autofac.Exception;
using Infrastructure.CrossCuttingConcerns.Logging.ElasticSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Interceptors
{
    // todo 11-> Attribute'ları Yakalayan mekanizma.
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //todo 12-> Önce Class Attribute'ları sonra Method Attribute'ları sistemden çekiliyor ve bunlar Priority'ye göre sıralanıp geri döndürülüyor.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList(); // ToList AddRange() methodu için gerekli.
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            // todo 53 -> Loglama için ElasticLogger LogAspect olarak Tanıtılır.
            classAttributes.Add(new ExceptionLogAspect(typeof(ElasticLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
