using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InvoiceSystem.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        public ObservableCollection<InvoiceNumberViewModel> InvoiceNumbers { get; }

        public ObservableCollection<InvoiceDateViewModel> InvoiceDates { get; }

        public ObservableCollection<TotalChargeViewModel> TotalCharges { get; }

        private int? selectedInvoiceNumber;

        public int? SelectedInvoiceNumber
        {
            get => selectedInvoiceNumber;
            set
            {
                if (value != selectedInvoiceNumber)
                {
                    selectedInvoiceNumber = value;
                    NotifyPropertyChanged();
                    ApplyFilters();
                }
            }
        }

        private DateTime? selectedInvoiceDate;

        public DateTime? SelectedInvoiceDate
        {
            get => selectedInvoiceDate;
            set
            {
                if (value != selectedInvoiceDate)
                {
                    selectedInvoiceDate = value;
                    NotifyPropertyChanged();
                    ApplyFilters();
                }
            }
        }

        private decimal? selectedTotalCharge;

        public decimal? SelectedTotalCharge
        {
            get => selectedTotalCharge;
            set
            {
                if (value != selectedTotalCharge)
                {
                    selectedTotalCharge = value;
                    NotifyPropertyChanged();
                    ApplyFilters();
                }
            }
        }

        private IList<InvoiceViewModel> AllInvoices { get; }

        private IList<InvoiceViewModel> filteredInvoices;

        public IList<InvoiceViewModel> FilteredInvoices
        {
            get => filteredInvoices;
            private set
            {
                if (value != filteredInvoices)
                {
                    filteredInvoices = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void ApplyFilters()
        {
            var query = AllInvoices.AsEnumerable();

            //Invoice number
            var selectedInvoiceNumber = SelectedInvoiceNumber;

            if (selectedInvoiceNumber != null)
            {
                var selectedInvoiceNumberValue = selectedInvoiceNumber.GetValueOrDefault();
                query = query.Where(invoice => invoice.Invoice.InvoiceNum == selectedInvoiceNumberValue);
            }

            //Invoice Date
            var selectedInvoiceDate = SelectedInvoiceDate;

            if (selectedInvoiceDate != null)
            {
                var selectedInvoiceDateValue = selectedInvoiceDate.GetValueOrDefault();
                query = query.Where(invoice => invoice.Invoice.InvoiceDate == selectedInvoiceDateValue);
            }

            //Total charge
            var selectedTotalCharge = SelectedTotalCharge;

            if (selectedTotalCharge != null)
            {
                var selectedTotalChargeValue = selectedTotalCharge.GetValueOrDefault();
                query = query.Where(invoice => invoice.Invoice.TotalCharge == selectedTotalChargeValue);
            }

            FilteredInvoices = query.ToList();

            return;
        }

        public SearchViewModel()
        {
            var invoices = SQL.LoadInvoices();
            AllInvoices = invoices.Select(invoice => new InvoiceViewModel(invoice)).ToList();

            var invoiceNumbers = new SortedSet<int>(invoices.Select(invoice => invoice.InvoiceNum)); // Filter duplicates
            var noInvoiceNumberViewModel = new[] { new InvoiceNumberViewModel(null) }; //So the selection can be nothing
            InvoiceNumbers = new ObservableCollection<InvoiceNumberViewModel>(noInvoiceNumberViewModel.Concat(invoiceNumbers.Select(invoiceNumber => new InvoiceNumberViewModel(invoiceNumber))));

            var invoiceDates = new SortedSet<DateTime>(invoices.Select(invoice => invoice.InvoiceDate)); // Filter duplicates
            var noDateViewModel = new[] { new InvoiceDateViewModel(null) }; //So the selection can be nothing
            InvoiceDates = new ObservableCollection<InvoiceDateViewModel>(noDateViewModel.Concat(invoiceDates.Select(invoiceDate => new InvoiceDateViewModel(invoiceDate))));

            var totalCharges = new SortedSet<decimal>(invoices.Select(invoice => invoice.TotalCharge)); // Filter duplicates
            var noTotalChargeViewModel = new[] { new TotalChargeViewModel(null) }; //So the selection can be nothing
            TotalCharges = new ObservableCollection<TotalChargeViewModel>(noTotalChargeViewModel.Concat(totalCharges.Select(totalCharge => new TotalChargeViewModel(totalCharge))));

            ApplyFilters();
        }
    }
}