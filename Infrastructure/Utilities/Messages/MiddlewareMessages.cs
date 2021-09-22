using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utilities.Messages
{
    // todo 17.2-> Sabit string (MagicString) verilerin tutulduğu yer. Veritabanından multilanguage datası çekilip update etme mekanizması olarak kullanılabilir.
    public static class MiddlewareMessages
    {
        /*
        public MiddlewareMessages(string culture) {
            -> GetByCulture(culture);
        }
        private void GetByCulture(string culture){
            -> Property'leri Veritabanından Culture'e göre çekip güncelle.
        }
         */
        public const string InternalServerError = "Internal Server Error";
    }
}
