using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewInvoice
{
    public class Setting : INotifyPropertyChanged
    {
        private string printerName;
        private double cGSTlessthan1000;
        private double sGSTlessthan1000;
        private double cGSTgreaterthan1000;
        private double sGSTgreaterthan1000;
        public string PrinterName { get => printerName; set { printerName = value; OnPropertyChanged("PrinterName"); } }
        public double CGSTLessThan1000 { get => cGSTlessthan1000; set { cGSTlessthan1000 = value; OnPropertyChanged("CGSTLessThan1000"); } }
        public double SGSTLessThan1000 { get => sGSTlessthan1000; set { sGSTlessthan1000 = value; OnPropertyChanged("SGSTLessThan1000"); } }
        public double CGSTGreaterThan1000 { get => cGSTgreaterthan1000; set { cGSTgreaterthan1000 = value; OnPropertyChanged("CGSTGreaterThan1000"); } }
        public double SGSTGreaterThan1000 { get => sGSTgreaterthan1000; set { sGSTgreaterthan1000 = value; OnPropertyChanged("SGSTGreaterThan1000"); } }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
