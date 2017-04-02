using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.Classes
{
    /// <summary>
    /// Class for handling Items.
    /// </summary>
    public class ItemService : INotifyPropertyChanged
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
        /// Current Item selected.
        /// </summary>
        private Item currentItem;

        /// <summary>
        /// This is the current item that the user has either selected from the search window, created, or is editing.
        /// </summary>
        public Item CurrentItem
        {
            get => currentItem;
            set
            {
                if (value != currentItem)
                {
                    currentItem = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
