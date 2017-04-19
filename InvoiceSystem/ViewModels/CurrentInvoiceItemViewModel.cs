using InvoiceSystem.Classes;
using InvoiceSystem.Models;
using System;
using System.Globalization;
using System.Reflection;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// To bind the current invoices line items and items to a datagrid within a view
    /// </summary>
    public class CurrentInvoiceItemViewModel
    {
        /// <summary>
        /// Data of a line item
        /// </summary>
        private LineItem lineItem;

        /// <summary>
        /// Data of item
        /// </summary>
        private Item item;

        /// <summary>
        /// The Line item
        /// </summary>
        public LineItem LineItem => lineItem;

        /// <summary>
        /// The Line item
        /// </summary>
        public Item Item => item;

        /// <summary>
        /// Takes a LineItem and Item and creats a CurrentInvoice viewmodel from them.
        /// </summary>
        /// <param name="lineItem"></param>
        /// <param name="item"></param>
        public CurrentInvoiceItemViewModel(LineItem lineItem, Item item)
        {
            try
            {
                this.lineItem = lineItem;
                this.item = item;
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

        /// <summary>
        /// The description of the item
        /// </summary>
        public string ItemDesc => item.ItemDesc.ToString();

        /// <summary>
        /// The cost of the item
        /// </summary>
        public string Cost => item.Cost.ToString("C", NumberFormatInfo.CurrentInfo);
    }
}
