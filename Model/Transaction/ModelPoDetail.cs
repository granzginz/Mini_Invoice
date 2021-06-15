using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Transaction
{
    public class ModelPoDetail
    {
        public Guid PO_H_ID { get; set; }
        public Guid PO_D_ID { get; set; }
        public Guid PO_D_Grid_ID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Discount_Name { get; set; }
        public decimal Total { get; set; }
        public Guid UOM_ID { get; set; }
        public string PO_Number { get; set; }

    }
}
