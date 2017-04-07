using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// To bind a control with invoice data
    /// </summary>
    public class InvoiceViewModel
    {
        private Invoice invoice;

        /// <summary>
        /// Can get or se the invoice.
        /// </summary>
        public Invoice Invoice => invoice;

        /// <summary>
        /// Creates an Invoice view model with the data
        /// </summary>
        /// <param name="invoice"></param>
        public InvoiceViewModel(Invoice invoice)
        {
            this.invoice = invoice;
        }

        /// <summary>
        /// The Invoice Number of a invoice
        /// </summary>
        public string InvoiceNum => invoice.InvoiceNum.ToString(NumberFormatInfo.InvariantInfo);

        /// <summary>
        /// The Invoice Date of a invoice
        /// </summary>
        public string InvoiceDate => invoice.InvoiceDate.ToShortDateString();

        /// <summary>
        /// The Total Charge of a invoice
        /// </summary>
        public string TotalCharge => invoice.TotalCharge.ToString("C", NumberFormatInfo.CurrentInfo);
    }
}
