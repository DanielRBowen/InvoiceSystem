using System.Windows;

namespace InvoiceSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Contains the logic for the application
        /// </summary>
        internal static InvoiceService InvoiceService { get; set; } = new InvoiceService();
    }
}
