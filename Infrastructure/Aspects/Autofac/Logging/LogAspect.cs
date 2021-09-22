using Castle.DynamicProxy;
using Infrastructure.CrossCuttingConcerns.Logging;
using Infrastructure.Utilities.Interceptors;
using Infrastructure.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aspects.Autofac.Logging
{
    // todo 45 -> Log Detaylarının Doldurulması için LogAspect entegre ediyoruz.
    public class LogAspect : MethodInterception
    {
        private ILoggerService _loggerServiceBase;

        public LogAspect(Type loggerService)
        {
            // todo 46-> Attribute ile Gönderilen loggerType LoggerService türünden'mi türetilmiş Onu Kontrol Ediyoruz.
            //  [LoggerService(xxx)]
            if (loggerService.BaseType != typeof(ILoggerService))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
        }

        // todo 47 Her Çağrılan Method'dan önce OnBefore'da Log Oluşturuyor
        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        // todo 48 -> Çalışan method üzerinden Object'i ve içerisindeki property'leri Json şeklinde alarak Log Detayı oluşturuluyor.
        private LogDetail GetLogDetail(IInvocation invocation)
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

            var logDetail = new LogDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
