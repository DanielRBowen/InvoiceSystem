﻿using InvoiceSystem.Classes;
using InvoiceSystem.ViewModels;
using System;
using System.Reflection;
using System.Windows;

namespace InvoiceSystem
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
        private void CreateNewInvoiceButton_Click(object sender, RoutedEventArgs e)
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
                    var invoice = new Invoice
                    {
                        InvoiceDate = (DateTime)InvoiceDatePicker.SelectedDate
                    };

                    App.InvoiceService.CurrentInvoice = invoice;

                    invoice.Save();
                    ViewModel.CurrentInvoice = invoice;
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
    }
}
