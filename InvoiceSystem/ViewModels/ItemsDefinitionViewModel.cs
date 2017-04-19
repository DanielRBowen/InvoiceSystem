using InvoiceSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemsDefinitionViewModel : ViewModel
    {
        /// <summary>
        /// A List of all Items from the database.
        /// </summary>
        private IList<ItemViewModel> allItems;

        /// <summary>
        /// A List of all Items from the database.
        /// </summary>
        public IList<ItemViewModel> AllItems
        {
            get => allItems;
            set
            {
                if (value != allItems)
                {
                    allItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private ItemViewModel selectedItem;

        /// <summary>
        /// The Item which is selected
        /// </summary>
        public ItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (value != selectedItem)
                {
                    selectedItem = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Constructor that gets all Items from the database.
        /// </summary>
        public ItemsDefinitionViewModel()
        {
            try
            {
                var items = DataStore.LoadAllItems();
                AllItems = items.Select(item => new ItemViewModel(item)).ToList();
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
    }
}
