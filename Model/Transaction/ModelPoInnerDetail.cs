using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Transaction
{
    public class ModelPoInnerDetail
    {
        public Guid PO_D_Grid_ID { get; set; }
        public int Sequence { get; set; }
        public int Quantity { get; set; }
        public float Rate { get; set; }
        public double Amount { get; set; }
        public double Unit_Name { get; set; }
      

    }
}
