using System;
using System.Collections.Generic;
using System.Linq;
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

        public MainViewModel()
        {
            //CurrentInvoiceItems = App.InvoiceService.CurrentInvoice.InvoiceLineItems;
        }
    }
}
