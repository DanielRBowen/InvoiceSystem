using InvoiceSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// MainViewModel for the main window
    /// </summary>
    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// List of items 
        /// </summary>
        private IList<ItemViewModel> currentInvoiceItems;

        /// <summary>
        /// The current items invoice
        /// Notifies that the property has changed and updates the view accordingly.
        /// </summary>
        public IList<ItemViewModel> CurrentInvoiceItems
        {
            get => currentInvoiceItems;
            private set
            {
                if (value != currentInvoiceItems)
                {
                    currentInvoiceItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// MainViewModel constructor to set things up
        /// </summary>
        public MainViewModel()
        {
            try
            {
                //CurrentInvoiceItems = App.InvoiceService.CurrentInvoice.InvoiceLineItems;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }  
        }
    }
}
