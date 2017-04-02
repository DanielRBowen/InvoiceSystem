using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InvoiceSystem
{
    /// <summary>
    /// A class which contains the main logic for the Invoice System
    /// Don’t forget to abstract your business logic into classes and keep you UI code clean.  
    /// </summary>
    public class InvoiceService : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// 
        /// </summary>
        private Invoice currentInvoice;

        /// <summary>
        /// 
        /// </summary>
        private bool isCurrentInvoiceSaved;


        /// <summary>
        /// This is the current invoice that the user has either selected from the search window, created, or is in editing.
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
        /// The data within the invoice will be locked if the invoice is saved. It will be in editing while it isn't. Controls will be enabled and diabled accordingly.
        /// </summary>
        public bool IsCurrentInvoiceSaved
        {
            get => isCurrentInvoiceSaved;
            set
            {
                if (value != isCurrentInvoiceSaved)
                {
                    isCurrentInvoiceSaved = value;
                    NotifyPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Contains the definiton table items that will be displayed in the search items combo boxes and the definition table grid
        /// Can add, edit, and delete items within the definition table window.
        /// Must retrieve and update from the database accordingly.
        /// </summary>
        public ObservableCollection<Item> Items { get; set; }


        /// <summary>
        /// Contains all the invoices found within the search window datagrid can add to in the main window 
        /// and can edit or delete current ones from the search window passed to the main window
        /// Must retrieve and update from the database accordingly.
        /// </summary>
        public ObservableCollection<Invoice> Invoices { get; set; }


        /// <summary>
        /// Default constructor when creating a new invoice system.
        /// </summary>
        public InvoiceService()
        {
        }
    }
}