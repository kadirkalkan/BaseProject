using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        // todo 33 -> Custom Validation Katmanı oluşturup fluentapi'ye gönderdiğimiz türde validation çalıştırıp hata durumunda middleware'e exception döndericez.
        public static void Validate(IValidator validator, object entity)
        {
            var result = validator.Validate(new ValidationContext<object>(entity));
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
