using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Results
{
    // todo 3-> Data Return için IResult implementation
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
