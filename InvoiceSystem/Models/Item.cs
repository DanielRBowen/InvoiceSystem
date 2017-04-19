using InvoiceSystem.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace InvoiceSystem
{
    /// <summary>
    /// An item that can be on an invoice. (ItemDesc)
    /// </summary>
    public class Item
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        public string ItemCode { get; set; }


        /// <summary>
        /// The description of an item
        /// </summary>
        public string ItemDesc { get; set; }


        /// <summary>
        /// The cost of an item
        /// </summary>
        public decimal Cost { get; set; }


        /// <summary>
        /// Saves an item or updates it if it already exists.
        /// </summary>
        internal void Save()
        {
            try
            {
                if (DataStore.ItemExists(ItemCode))
                {
                    DataStore.UpdateItem(this);
                }
                else
                {
                    DataStore.InsertItem(this);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


        /// <summary>
        /// Tries to delete an item if it does not exist on an invoice.
        /// </summary>
        /// <returns></returns>
        internal IList<LineItem> TryDelete()
        {
            try
            {
                var lineItems = DataStore.ItemExistsOnInvoice(ItemCode);
                if (lineItems != null)
                {
                    return lineItems;
                }
                else
                {
                    DataStore.DeleteItem(this);
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
