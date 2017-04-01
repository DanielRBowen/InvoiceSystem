using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    /// <summary>
    /// Contains the items that can be displayed in the data grid of the definition table
    /// </summary>
    public class Items : IEnumerable<Item>
    {
        /// <summary>
        /// Contains a list of items
        /// </summary>
        private List<Item> ItemList { get; set; } = new List<Item>();

        /// <summary>
        /// Enumerator interface of items from the item list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Item> GetEnumerator() => ItemList.GetEnumerator();

        /// <summary>
        /// The matching return type of IEnumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
