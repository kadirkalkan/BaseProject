using Castle.DynamicProxy;
using FluentValidation;
using Infrastructure.CrossCuttingConcerns.Validation;
using Infrastructure.Utilities.Interceptors;
using Infrastructure.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Aspects.Autofac.Validation
{
    // todo 37 -> Oluşturduğumuz MethodInterception'dan türetiyoruz.
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        //todo 38 -> Yazılımın gönderdiği type doğrumu diye bir kontrol mekanizması oluşturuyoruz.
        public ValidationAspect(Type validatorType)
        {
            // todo 39-> Attribute ile Gönderilen validatorType FluentValidator'ın IValidator türünden'mi türetilmiş Onu Kontrol Ediyoruz.
            //  [AspectValidator(xxx)]
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }

        // todo 40 -> Attribute olarak Validation kontrolü yapacağımızdan OnBefore Fonksiyonunu override ediyoruz.
        protected override void OnBefore(IInvocation invocation)
        {
            // todo 41 -> İlgili Validator'dan Bir Instance üretiyoruz. 
            var validator = (AbstractValidator<object>)Activator.CreateInstance(_validatorType);
            // todo 42 -> İlgili ValidatorType'ın BaseType'ının Argument'i AbstractValidator<OrderRequest> --> OrderRequest çekilir.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            // todo 43 -> Method'un Argument'i Get(OrderRequest data) ---- OrderRequest Olanlar çekilir.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            // todo 44 -> Foreach ValidationTool'a validator ve entity gönderilip RuleFor Çalıştırılır.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
