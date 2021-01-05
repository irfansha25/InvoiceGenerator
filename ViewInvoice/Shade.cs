using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ViewInvoice
{
    public class Shade : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string shadeCode;
        private string itemName;
        private double rate;
        public int ShadeId { get; set; }
        public string ShadeCode { get => shadeCode; set { shadeCode = value; OnPropertyChanged("ShadeCode"); } }
        public string ItemName { get => itemName; set { itemName = value; OnPropertyChanged("ItemName"); } }
        public double Rate { get => rate; set { rate = value; OnPropertyChanged("Rate"); } }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
