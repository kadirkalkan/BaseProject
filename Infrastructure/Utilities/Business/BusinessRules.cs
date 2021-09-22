using Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Business
{
    // todo 13-> Bir işlemler dizisi çalıştırıp bütün hepsinin çalıştığından emin olmak için kullanılacak Class.
    public class BusinessRules 
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
