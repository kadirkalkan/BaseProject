using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CrossCuttingConcerns.Logging
{
    // todo 36->Log Detail Class'ından Türetiliyor ve Hata Detayını Log'a basıyor oluşturulur.
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}
