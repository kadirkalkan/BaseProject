using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Results
{
    // todo 4-> Data Return için IDataResult implementation
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        
        public DataResult(T data, bool success): base (success)
        {
            Data = data;
        }

        public T Data { get;  }
    }
}
