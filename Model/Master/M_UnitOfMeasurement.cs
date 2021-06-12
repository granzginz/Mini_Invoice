using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Master
{
    public class M_UnitOfMeasurement
    {
        public UniqueConstraint UOM_ID { get; set; }
        public string Unit_Name { get; set; }
        public string Description { get; set; }
    }
}
