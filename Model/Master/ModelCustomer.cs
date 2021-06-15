using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Master
{
    public class ModelCustomer
    {
        public Guid Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Company { get; set; }

    }
}
