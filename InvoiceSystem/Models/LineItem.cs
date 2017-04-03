using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Models
{
    public class LineItem
    {
        public int InvoiceNumber { get; set; }

        public int LineItemNumber { get; set; }

        public string ItemCode { get; set; }
    }
}
