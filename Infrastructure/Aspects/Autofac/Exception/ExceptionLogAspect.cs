using Castle.DynamicProxy;
using Infrastructure.CrossCuttingConcerns.Logging;
using Infrastructure.Utilities.Interceptors;
using Infrastructure.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aspects.Autofac.Exception
{
    // todo 49 -> LogAspect'den ayırma nedenimiz 1- OnBefore'da değil OnException'da çalışması gereken bir Aspect. 2-> Burada Info yerine Warning veya Error gibi Logging'leri implemente edicez.
    // Performans ve Single Responsibility için LogAspect ve ExceptionLogAspect'i birbirinden ayırdık.
    public class ExceptionLogAspect : MethodInterception
    {
        private ILoggerService _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            // todo 50-> Attribute ile Gönderilen loggerType LoggerService türünden'mi türetilmiş Onu Kontrol Ediyoruz.
            //  [LoggerService(xxx)]
            if (loggerService.BaseType != typeof(ILoggerService))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
        }

        // todo 51 -> Her Hata durumunda çalışan OnException Override Edip ExceptionLogDetail'i customize ediyoruz.
        protected override void OnException(IInvocation invocation, System.Exception exception)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = exception.Message;
            _loggerServiceBase.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailWithException = new LogDetailWithException
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailWithException;
        }
    }
}
