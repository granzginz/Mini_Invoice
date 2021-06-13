using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Master
{
    public class ModelLanguage
    {
        public UniqueConstraint Language_ID { get; set; }
        public string Initial { get; set; }
        public string Description { get; set; }
    }
}
