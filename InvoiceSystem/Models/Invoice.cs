using System;
using System.Collections.Generic;

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
        /// Calculates the total charge
        /// </summary>
        /// <param name="items"></param>
        private void CalculateTotalCharge(List<Item> items)
        {
            decimal totalCharge = 0;
            foreach (var item in items)
            {
                totalCharge += item.Cost;
            }

            TotalCharge = totalCharge;
        }

        /// <summary>
        /// Saves the invoice. Updates the data if it exists or inserts the data if it doesn't
        /// </summary>
        public void Save(List<Item> items = null)
        {
            if (items != null)
            {
                CalculateTotalCharge(items);
            }

            if (DataStore.InvoiceExists(InvoiceNum))
            {
                DataStore.UpdateInvoice(this);
            }
            else
            {
                InvoiceNum = DataStore.InsertInvoice(this);
            }
        }
    }
}
