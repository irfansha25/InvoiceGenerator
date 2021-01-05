using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ViewModelInvoice
{
    public class PercentageValidationRule : ValidationRule
    {
        public string FieldName { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string percentageVal = value as string;
            float number;
            if (string.IsNullOrWhiteSpace(percentageVal))
                return new ValidationResult(false, FieldName + " is Empty");
            else if(!(float.TryParse(percentageVal, out number) && number <= 100))
                return new ValidationResult(false, FieldName + " is not valid");
            else
                return ValidationResult.ValidResult;
        }
    }
}
