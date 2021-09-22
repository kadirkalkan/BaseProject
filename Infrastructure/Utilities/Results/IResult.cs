using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Results
{
    // todo 1-> Geri Dönecek Her Türlü Response İçin.
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }
}
