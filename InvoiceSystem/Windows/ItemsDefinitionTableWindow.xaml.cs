using InvoiceSystem.Classes;
using InvoiceSystem.ViewModels;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Input;

namespace InvoiceSystem.Windows
{
    /// <summary>
    /// Interaction logic for DefinitionTableWindow.xaml
    /// </summary>
    public partial class ItemsDefinitionTableWindow : Window
    {
        /// <summary>
        /// 
        /// </summary>
        private ItemsDefinitionViewModel ViewModel => (ItemsDefinitionViewModel)DataContext;

        /// <summary>
        /// The last form needed is a form to update the def table which contains all the items for the business.  
        /// This form can be accessed through the menu and only when an invoice is not being edited or a new invoice is being entered.  
        /// This form will list all the items in a list (like a DataGrid).  
        /// The items will consist of a name, cost, and description.  
        /// From here the user can add new items, edit existing items, or delete existing items.  
        /// If the user tries to delete an item that is on an invoice, don’t allow the user to do so.  
        /// Instead warn them with a message that tells the user which invoices that item is used on.  
        /// When the user closes the update def table form, make sure to update the drop down box as to reflect any changes made by the user.  
        /// Also update the current invoice because its item name might have been updated.
        /// </summary>
        public ItemsDefinitionTableWindow()
        {
            try
            {
                InitializeComponent();
                DataContext = new ItemsDefinitionViewModel();
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
        /// Cancels the definition table window and returns to the main window.
        /// 
        /// When the user closes the update def table form, make sure to update the drop down box as to reflect any changes made by the user.
        /// Also update the current invoice because its item name might have been updated.
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
        /// Saves item to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
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
        /// Adds an Item to the item definitions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddEditItemGrpbx.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Edits an Item definition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ViewModel.SelectedItem != null)
                {
                    
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Deletes an item
        /// 
        /// If the user tries to delete an item that is on an invoice, don’t allow the user to do so.
        /// Instead warn them with a message that tells the user which invoices that item is used on.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                ViewModel.SelectedItem = (ItemViewModel)ItemDataGrid.SelectedItem;
                AddEditItemGrpbx.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Only allow letters and numbers to be entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemNameTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                // Only allow letters and numbers to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.D0 && e.Key <= Key.D9)))
                {
                    // Allow the user to use the backspace, delete, tab, enter, left & right arrow keys, and space
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter
                            || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Space))
                    {
                        // No other keys allowed besides numbers, backspace, delete, tab, enter, left & right arrow keys, and space
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Only allow numbers to be entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCostTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Only allow numbers to be entered
                if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
                {
                    // Allow the user to use the backspace, delete, tab, enter, left & right arrow keys, and space
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter
                            || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Space))
                    {
                        // No other keys allowed besides numbers, backspace, delete, tab, enter, left & right arrow keys, and space
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        /// <summary>
        /// Only allow letters, numbers, space, dash, and slash to be entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemDescriptionTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Only allow letters, numbers, space, dash, and slash to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z || (e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Space || e.Key == Key.OemMinus || e.Key == Key.OemQuestion))
                {
                    // Allow the user to use the backspace, delete, tab, enter, left & right arrow keys, and space
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter
                            || e.Key == Key.Left || e.Key == Key.Right || e.Key == Key.Space))
                    {
                        // No other keys allowed besides numbers, backspace, delete, tab, enter, left & right arrow keys, and space
                        e.Handled = true;
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
