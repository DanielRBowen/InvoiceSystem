using InvoiceSystem.Classes;
using InvoiceSystem.ViewModels;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;

namespace InvoiceSystem
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        /// <summary>
        /// The user also needs to be able to search for invoices, which will be a choice from the menu.
        /// On the search screen all invoices should be displayed in a list (like a DataGrid) for the user to select.  
        /// The user may limit the invoices displayed by choosing an Invoice Number from a drop down, selecting an invoice date, 
        /// or selecting the total charge from a drop down box.  When a limiting item is selected the list should only reflect those invoices that match the criteria.  
        /// A clear selection button should reset the form to its initial state. 
        /// Once an invoice is selected the user will click a “Select Invoice” button, which will close the search form and open the selected invoice up for viewing on the main screen.  
        /// From there the user may choose to Edit or Delete the invoice.
        /// </summary>
        public SearchWindow()
        {
            try
            {
                InitializeComponent();

                DataContext = new SearchViewModel();
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Handles the closing event.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                base.OnClosing(e);
                new MainWindow().Show();
                return;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Once an invoice is selected the user will click a “Select Invoice” button, which will close the search form and open the selected invoice up for viewing on the main screen.  
        /// From there the user may choose to Edit or Delete the invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Set Current Invoice in App.InvoiceService
                var selectedInvoice = (InvoiceViewModel)InvoiceDataGrid.SelectedItem;
                App.InvoiceService.CurrentInvoice = selectedInvoice.Invoice;
                Close();
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// Cancels the search and closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// A clear selection button should reset the form to its initial state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InvoiceNumberComboBox.SelectedValue = null;
                InvoiceDateComboBox.SelectedValue = null;
                TotalChargeComboBox.SelectedValue = null;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
    }
}
