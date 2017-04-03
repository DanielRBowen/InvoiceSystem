using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    public class InvoiceViewModel
    {
        private Invoice invoice;

        public Invoice Invoice => invoice;

        public InvoiceViewModel(Invoice invoice)
        {
            this.invoice = invoice;
        }

        public string InvoiceNum => invoice.InvoiceNum.ToString(NumberFormatInfo.InvariantInfo);

        public string InvoiceDate => invoice.InvoiceDate.ToShortDateString();

        public string TotalCharge => invoice.TotalCharge.ToString("C", NumberFormatInfo.CurrentInfo);
    }
}
