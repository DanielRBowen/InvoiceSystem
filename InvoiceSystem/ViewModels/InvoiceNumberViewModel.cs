namespace InvoiceSystem.ViewModels
{
    /// <summary>
    /// To bind a control with a invoice number
    /// </summary>
    public class InvoiceNumberViewModel
    {
        /// <summary>
        /// The constructor of the invoice Number view model takes the value of the invoice number
        /// </summary>
        /// <param name="value"></param>
        public InvoiceNumberViewModel(int? value)
        {
            Value = value;
            Text = value?.ToString();
        }

        /// <summary>
        /// The text of the viewmodel, binds the the value of the data 
        /// to the text of the control it is bound.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// The value of the number
        /// </summary>
        public int? Value { get; }

        /// <summary>
        /// The to string method just returns the text
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Text;
    }
}
