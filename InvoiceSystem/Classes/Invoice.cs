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
        public int InvoiceID { get; set; }


        /// <summary>
        /// The Date which the invoice was made
        /// </summary>
        public DateTime InvoiceDate { get; set; }


        /// <summary>
        /// The total charge that the invoice totaled
        /// Should be all the items in the list added up
        /// </summary>
        public float TotalCharge
        {
            get
            {
                float totalCharge = 0;
                foreach (var item in InvoiceItems)
                {
                    totalCharge += item.Cost;
                }

                return totalCharge;
            }
        }


        /// <summary>
        /// The items sold
        /// </summary>
        public List<Item> InvoiceLineItems { get; set; }
    }
}
