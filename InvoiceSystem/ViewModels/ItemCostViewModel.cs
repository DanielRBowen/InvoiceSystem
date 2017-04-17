using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSystem.ViewModels
{
    public class ItemCostViewModel
    {
        /// <summary>
        /// The constructor of the total charge view model takes the value of the invoice total charge
        /// </summary>
        /// <param name="value"></param>
        public ItemCostViewModel(decimal? value)
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
        /// The value of the total charge
        /// </summary>
        public decimal? Value { get; }

        /// <summary>
        /// The to string method just returns the text
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Text;
    }
}
