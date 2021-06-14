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
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Rate { get; set; }
        public double Amount { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Total { get; set; }
        public Guid UOM_ID { get; set; }
        public string PO_Number { get; set; }

    }
}
