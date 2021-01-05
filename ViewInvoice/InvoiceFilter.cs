using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewInvoice
{
    public class InvoiceFilter : INotifyPropertyChanged
    {
        public ObservableCollection<TaxInvoice> TaxInvoices { get; set; } = new ObservableCollection<TaxInvoice>();
        private double cGST;
        private double sGST;
        private double iGST;
        private double grandTotal;
        public double FilterCGSTAmount { get => cGST; set { cGST = value; OnPropertyChanged("FilterCGSTAmount"); } }
        public double FilterSGSTAmount { get => sGST; set { sGST = value; OnPropertyChanged("FilterSGSTAmount"); } }
        public double FilterIGSTAmount { get => iGST; set { iGST = value; OnPropertyChanged("FilterIGSTAmount"); } }
        public double FilterGrandTotal { get => grandTotal; set { grandTotal = value; OnPropertyChanged("FilterGrandTotal"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
