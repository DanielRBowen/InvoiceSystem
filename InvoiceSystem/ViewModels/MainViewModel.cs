using InvoiceSystem.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        /// List of line item viewmodel 
        /// </summary>
        private ObservableCollection<CurrentInvoiceItemViewModel> currentInvoiceItems;

        /// <summary>
        /// The current items invoice
        /// Notifies that the property has changed and updates the view accordingly.
        /// </summary>
        public ObservableCollection<CurrentInvoiceItemViewModel> CurrentInvoiceItems
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
                if (App.InvoiceService.CurrentInvoice != null)
                {
                    CurrentInvoiceItems = new ObservableCollection<CurrentInvoiceItemViewModel>();

                    var lineItems = SQL.LoadLineItems(App.InvoiceService.CurrentInvoice);

                    foreach (var line in lineItems)
                    {
                        CurrentInvoiceItems.Add(new CurrentInvoiceItemViewModel(line, SQL.LoadItem(line)));
                    }
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
    }
}
