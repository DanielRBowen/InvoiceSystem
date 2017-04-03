using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    public class TotalChargeViewModel
    {
        public TotalChargeViewModel(decimal? value)
        {
            Value = value;
            Text = value?.ToString();
        }

        public string Text { get; }

        public decimal? Value { get; }

        public override string ToString() => Text;
    }
}
