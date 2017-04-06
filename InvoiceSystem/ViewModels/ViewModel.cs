using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// The a viewmodel abstract class that is overriden by a viewmodel
    /// Is a INotifyPropertyChanged class which will Invoke a PropertyChangeEventArgs 
    /// when ever a property is changed the NotifyPropertyChanged method is called and then the viewmodel is updated with the changed property.
    /// </summary>
    public abstract class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event handler for when the property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// When ever a property is changed the NotifyPropertyChanged method is called and then the viewmodel is updated with the changed property.
        /// </summary>
        /// <param name="propertyName"></param>
        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}