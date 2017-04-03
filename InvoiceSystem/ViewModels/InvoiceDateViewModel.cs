using System;

namespace InvoiceSystem.ViewModels
{
    public class InvoiceDateViewModel
    {
        public InvoiceDateViewModel(DateTime? value)
        {
            Value = value;
            Text = value?.ToShortDateString();
        }

        public string Text { get; }

        public DateTime? Value { get; }

        public override string ToString() => Text;
    }
}
