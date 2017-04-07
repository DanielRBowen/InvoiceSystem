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
    }
}
