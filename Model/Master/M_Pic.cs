using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Master
{
    public class M_Pic
    {
        public UniqueConstraint PIC_ID { get; set; }
        public string Name { get; set; }
    }
}
