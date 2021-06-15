using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MiniInvoiceAPI.Model.Transaction
{
    public class ModelPoHeader
    {
        public Guid PO_H_ID { get; set; }
        public Guid Currency_id { get; set; }
        public string Addr_From { get; set; }
        public string Addr_To { get; set; }
        public DateTime Date { get; set; }
        public DateTime InvoiceDue { get; set; }
        public string PO_Number { get; set; }
        public string Inv_Number { get; set; }
        public string Logo { get; set; }
        public string Language_id { get; set; }
        public string Language_initial { get; set; }
        public string Currency_initial { get; set; }
        public string Name_Customer { get; set; }
    }
}
