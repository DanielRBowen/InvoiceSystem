using InvoiceSystem.Classes;
using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// To bind line item data to a view
    /// </summary>
    public class LineItemViewModel
    {
        private LineItem lineItem;

        /// <summary>
        /// The Line item
        /// </summary>
        public LineItem LineItem => lineItem;

        /// <summary>
        /// Constructor takes a line item model to make it into a viewmodel
        /// </summary>
        /// <param name="lineItem"></param>
        public LineItemViewModel(LineItem lineItem)
        {
            try
            {
                this.lineItem = lineItem;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// The invoice number of a line item as a string
        /// </summary>
        public string InvoiceNum => lineItem.InvoiceNumber.ToString(NumberFormatInfo.InvariantInfo);

        /// <summary>
        /// The line item number of an item as a string
        /// </summary>
        public string LineItemNum => lineItem.LineItemNumber.ToString(NumberFormatInfo.InvariantInfo);

        /// <summary>
        /// The Item code of a line item as a string
        /// </summary>
        public string ItemCode => lineItem.ItemCode.ToString();
    }
}
