using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    /// <summary>
    /// An item that can be on an invoice
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The cost of an item
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// The description of an item
        /// </summary>
        public string Description { get; set; }
    }
}
