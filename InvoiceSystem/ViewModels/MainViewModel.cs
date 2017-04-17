using InvoiceSystem.Classes;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// MainViewModel for the main window
    /// </summary>
    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// A List of all Items from the database.
        /// </summary>
        public ObservableCollection<ItemViewModel> AllItems { get; }

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

        private Invoice currentInvoice;

        /// <summary>
        /// This is the current invoice
        /// </summary>
        public Invoice CurrentInvoice
        {
            get => currentInvoice;
            set
            {
                if (value != currentInvoice)
                {
                    currentInvoice = value;
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
                var items = SQL.LoadAllItems();
                AllItems = new ObservableCollection<ItemViewModel>(items.Select(item => new ItemViewModel(item)));

                currentInvoice = App.InvoiceService.CurrentInvoice;
                if (currentInvoice != null)
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
