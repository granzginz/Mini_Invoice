using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Master
{
    public class ModelPo
    {
        public Guid PO_ID { get; set; }
        public Guid PIC_ID { get; set; }
        public string PO_Number { get; set; }
        public double Amount { get; set; }
    }
}
