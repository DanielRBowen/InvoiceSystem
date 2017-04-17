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
        /// The current invoice
        /// </summary>
        private Invoice currentInvoice;


        /// <summary>
        /// This is the current invoice that the user has either selected from the search window, created, or is editing.
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
    }
}