using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    public class InvoiceNumberViewModel
    {
        public InvoiceNumberViewModel(int? value)
        {
            Value = value;
            Text = value?.ToString();
        }

        public string Text { get; }

        public int? Value { get; }

        public override string ToString() => Text;
    }
}
