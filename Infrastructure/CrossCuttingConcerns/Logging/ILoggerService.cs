using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Logging
{
    // todo 34 -> Custom logger service'i oluşturuyoruz. Bütün log sistemini middleware tarzı tek bir noktaya bağlamak için.
    public interface ILoggerService
    {
        void Info(object logService);
        void Debug(object logService);
        void Warn(object logService);
        void Fatal(object logService);
        void Error(object logService);
    }
}
