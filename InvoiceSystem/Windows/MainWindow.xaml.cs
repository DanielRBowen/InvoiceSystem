using InvoiceSystem.Classes;
using InvoiceSystem.Models;
using InvoiceSystem.ViewModels;
using System;
using System.Reflection;
using System.Windows;

namespace InvoiceSystem.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel ViewModel => (MainViewModel)DataContext;
        /// <summary>
        /// The main form should allow the user to create new invoices, edit existing invoices, or delete existing invoices.  
        /// It will also have a menu that will have two functionalities.  
        /// The first will allow the user to update a def table that contains the items.
        /// The next will be to open a search screen used to search for invoices.
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                DataContext = new MainViewModel();

                ItemControlsGroup.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// If a new invoice is created the user may enter data pertaining to that invoice.  
        /// An auto-generated number from the database will be given to the invoice as the invoice number.  
        /// An invoice date will also be assigned by the user.  Next different items will be entered by the user.  
        /// The items will be selected from a drop down box and the cost for that item will be put into a read only textbox.  
        /// This will be the default cost of an item. Once the item is selected, the user can add the item.  As many items as needed should be able to be added.  
        /// All items entered should be displayed for viewing in a list (something like a DataGrid).  Items may be deleted from the list.
        /// A running total of the cost should be displayed as items are entered or deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateSaveInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InvoiceDatePicker.SelectedDate == null)
                {
                    MessageBox.Show(this, "Please select a date.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    InvoiceDatePicker.Focus();
                }
                else
                {
                    var invoice = App.InvoiceService.CurrentInvoice;
                    if (invoice == null)
                    {
                        invoice = new Invoice
                        {
                            InvoiceDate = (DateTime)InvoiceDatePicker.SelectedDate
                        };

                        App.InvoiceService.CurrentInvoice = invoice;
                        MessageBox.Show(this, "Invoice Created", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Invoice Saved", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    ViewModel.RefreshInvoice();
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Once all the items are entered the user can save the invoice.  
        /// This will lock the data in the invoice for viewing only.  
        /// From here the user may choose to Edit the Invoice or Delete the Invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var invoice = App.InvoiceService.CurrentInvoice;
                if (invoice == null)
                {
                    MessageBox.Show(this, "There is no Invoice to Edit.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    ItemControlsGroup.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Once all the items are entered the user can save the invoice.  
        /// This will lock the data in the invoice for viewing only.  
        /// From here the user may choose to Edit the Invoice or Delete the Invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteInvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var invoice = App.InvoiceService.CurrentInvoice;
                if (invoice == null)
                {
                    MessageBox.Show(this, "There is no Invoice to Delete.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if(MessageBox.Show(this, "Are you sure you want to delete this invoice?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    {
                        return;
                    }
                    var deleted = invoice.TryDelete();
                    if (deleted)
                    {
                        App.InvoiceService.CurrentInvoice = null;
                        ViewModel.RefreshInvoice();
                    }
                    else
                    {
                        MessageBox.Show(this, "Invoice could not be deleted.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Opens up a search window
        /// Pass any info needed in the search window then closes this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchWindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new SearchWindow().Show();
                Close();
                return;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Opens up a new definition table window
        /// Pass any info needed in the Definition table window then closes this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefinitionTableWindowButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new ItemsDefinitionTableWindow().Show();
                Close();
                return;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Adds an Item to the invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var invoice = App.InvoiceService.CurrentInvoice;
                if (invoice == null)
                {
                    MessageBox.Show(this, "Please create or select an Invoice.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var itemViewModel = (ItemViewModel)ItemsComboBox.SelectedItem;
                if (itemViewModel == null)
                {
                    MessageBox.Show(this, "Please select an item to add to the invoice.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var item = itemViewModel.Item;
                var lineItemNumber = DataStore.AddItemToInvoice(invoice, item);

                var lineItem = new LineItem
                {
                    InvoiceNumber = invoice.InvoiceNum,
                    ItemCode = item.ItemCode,
                    LineItemNumber = lineItemNumber
                };

                var currentInvoiceItemViewModel = new CurrentInvoiceItemViewModel(lineItem, item);
                ViewModel.CurrentInvoiceItems.Add(currentInvoiceItemViewModel);

                ViewModel.RefreshInvoice();
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }

}

        /// <summary>
        /// Method for when the delete items button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentInvoiceItemViewModel = (CurrentInvoiceItemViewModel)ItemDataGrid.SelectedItem;
                if(currentInvoiceItemViewModel == null)
                {
                    MessageBox.Show(this, "Items have not been selected.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;

                }
                else
                {
                    if (MessageBox.Show(this, "Are you sure you want to delete this item?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                    {
                        return;
                    }
                    var lineItem = currentInvoiceItemViewModel.LineItem;
                    var deleted = lineItem.TryDelete();
                    if(deleted)
                    {
                        ViewModel.CurrentInvoiceItems.Remove(currentInvoiceItemViewModel);
                        ViewModel.RefreshInvoice();
                    }
                    else
                    {
                        MessageBox.Show(this, "Line items could not be deleted.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
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
