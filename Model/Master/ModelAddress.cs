using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Master
{
    public class ModelAddress
    {
        public UniqueConstraint Addres_ID { get; set; }
        public UniqueConstraint CustomerID { get; set; }
        public String Address_Name { get; set; }

    }
}
