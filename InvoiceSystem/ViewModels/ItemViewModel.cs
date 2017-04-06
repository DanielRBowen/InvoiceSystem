using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// To bind a control with item data
    /// </summary>
    public class ItemViewModel
    {
        /// <summary>
        /// Data of item
        /// </summary>
        private Item item;

        /// <summary>
        /// get or set the item
        /// </summary>
        public Item Item => item;

        /// <summary>
        /// Create an item view model with the data
        /// </summary>
        /// <param name="item"></param>
        public ItemViewModel(Item item)
        {
            this.item = item;
        }

        /// <summary>
        /// Item code of the item
        /// </summary>
        public string ItemCode => item.ItemCode.ToString();

        /// <summary>
        /// The description of the item
        /// </summary>
        public string ItemDesc => item.ItemDesc.ToString();

        /// <summary>
        /// The cost of the item
        /// </summary>
        public string Cost => item.Cost.ToString(NumberFormatInfo.CurrentInfo);
    }
}
