using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ViewModelInvoice
{
    public class GSTNoValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string GSTNo = value as string;
            Regex regex = new Regex(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$");
            if (string.IsNullOrWhiteSpace(GSTNo))
                return new ValidationResult(false, "GST Number is Empty");
            else if (!regex.IsMatch(GSTNo))
                return new ValidationResult(false, "GST Number is not valid");
            else
                return ValidationResult.ValidResult;
        }
    }
}
