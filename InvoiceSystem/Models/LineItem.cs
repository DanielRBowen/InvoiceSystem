using System;
using System.Reflection;

namespace InvoiceSystem.Models
{
    /// <summary>
    /// A model of a line item that taken from the data
    /// </summary>
    public class LineItem
    {
        /// <summary>
        /// The invoice number of a line item.
        /// </summary>
        public int InvoiceNumber { get; set; }

        /// <summary>
        /// The line item number of a line item
        /// </summary>
        public int LineItemNumber { get; set; }

        /// <summary>
        /// The item code of a line item.
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Bool to try and delete current line item
        /// </summary>
        /// <returns></returns>
        public bool TryDelete()
        {
            try
            {
                var lineItemExists = DataStore.LineItemExists(this);
                if(lineItemExists)
                {
                    DataStore.DeleteLineItem(this);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
