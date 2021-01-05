using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace ViewModelInvoice
{
    public class AmountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values.Count() == 2)
                {
                    double rate = (double)values[1];
                    int quantity = (int)values[0];
                    return (rate * quantity).ToString();
                }
                else
                    return "0";
            }
            catch (Exception)
            {
                return "0";
            }
           

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
