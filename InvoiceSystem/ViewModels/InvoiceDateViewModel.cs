using System;

namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// Binds a control with a invoice Date
    /// </summary>
    public class InvoiceDateViewModel
    {
        /// <summary>
        /// The constructor of the Date view model takes the value of the invoice date
        /// </summary>
        /// <param name="value"></param>
        public InvoiceDateViewModel(DateTime? value)
        {
            Value = value;
            Text = value?.ToShortDateString();
        }

        /// <summary>
        /// The text of the viewmodel, binds the the value of the data 
        /// to the text of the control it is bound.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The value of the Date
        /// </summary>
        public DateTime? Value { get; }

        /// <summary>
        /// The to string method just returns the text
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Text;
    }
}
