using InvoiceSystem.Classes;
using System;
using System.Collections.Generic;
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

        private InvoiceViewModel currentInvoiceViewModel;

        /// <summary>
        /// To display data such as Total charge in a format for viewing.
        /// </summary>
        public InvoiceViewModel CurrentInvoiceViewModel
        {
            get => currentInvoiceViewModel;
            set
            {
                if (value != currentInvoiceViewModel)
                {
                    currentInvoiceViewModel = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Refreshes the Current Invoice View Model
        /// </summary>
        public void RefreshInvoice()
        {
            var currentInvoice = App.InvoiceService.CurrentInvoice;

            // Load the view with the data saved
            CurrentInvoiceItems = new ObservableCollection<CurrentInvoiceItemViewModel>();

            // Save the data if the current invoice isn't null
            if (currentInvoice != null)
            {
                var lineItems = DataStore.LoadLineItems(App.InvoiceService.CurrentInvoice);

                foreach (var line in lineItems)
                {
                    CurrentInvoiceItems.Add(new CurrentInvoiceItemViewModel(line, DataStore.LoadItem(line)));
                }

                var itemViews = CurrentInvoiceItems;
                var items = new List<Item>(itemViews.Select(itemView => itemView.Item));

                if (items.Count > 0)
                {
                    currentInvoice.Save(items);
                }
                else
                {
                    currentInvoice.Save();
                }

                CurrentInvoiceViewModel = new InvoiceViewModel(currentInvoice);
            }
            else
            {
                CurrentInvoiceViewModel = null;
            }
        }

        /// <summary>
        /// MainViewModel constructor to set things up
        /// </summary>
        public MainViewModel()
        {
            try
            {
                var items = DataStore.LoadAllItems();
                AllItems = new ObservableCollection<ItemViewModel>(items.Select(item => new ItemViewModel(item)));

                RefreshInvoice();
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
    }
}
