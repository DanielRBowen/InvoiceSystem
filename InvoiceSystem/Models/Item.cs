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

        internal void Save()
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
    }
}
