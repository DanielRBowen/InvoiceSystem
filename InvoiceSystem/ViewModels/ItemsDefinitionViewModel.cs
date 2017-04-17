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
        public IList<ItemViewModel> AllItems { get; }


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
