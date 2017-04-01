using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceSystem.Classes
{
    /// <summary>
    /// Class for handling errors.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Handles Error messages
        /// All methods should handle exceptions.  
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="exception"></param>
        public static void HandleError(string sClass, string sMethod, Exception exception)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + exception.Message + "---- " + exception.StackTrace);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
