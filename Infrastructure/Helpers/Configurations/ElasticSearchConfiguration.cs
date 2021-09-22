using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers.Configurations
{
    // todo 32 -> ElasticSearch için Configuration Class'ı tanımlanır ve Host URL'i tanımlanır. 
    public class ElasticSearchConfiguration
    {
#if DEBUG
        public const string Host = "http://localhost:9200";
#else
        public const string Host = "http://elasticsearch:9200";
#endif
    }
}
