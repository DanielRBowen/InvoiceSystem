using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    /// <summary>
    /// Contains the information for an invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// A unique ID for an invoice (InvoiceNum from database)
        /// </summary>
        public int InvoiceNum { get; set; }


        /// <summary>
        /// The Date which the invoice was made
        /// </summary>
        public DateTime InvoiceDate { get; set; }


        /// <summary>
        /// The total charge that the invoice totaled
        /// Should be all the items in the list added up
        /// </summary>
        public decimal TotalCharge { get; set; }


        /// <summary>
        /// The items sold
        /// </summary>
        public List<LineItem> InvoiceLineItems { get; set; }
    }
}
