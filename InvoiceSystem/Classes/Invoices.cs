using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem
{
    /// <summary>
    /// Contains all the invoices as an Enumerable object
    /// </summary>
    public class Invoices : IEnumerable<Invoice>
    {
        /// <summary>
        /// Contains a list of invoices
        /// </summary>
        private List<Invoice> InvoiceList { get; set; } = new List<Invoice>();

        /// <summary>
        /// Enumerator interface of invoices from the Invoice list.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Invoice> GetEnumerator() => InvoiceList.GetEnumerator();

        /// <summary>
        /// The matching return type of IEnumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
