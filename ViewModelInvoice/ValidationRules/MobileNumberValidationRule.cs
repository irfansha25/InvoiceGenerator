using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ViewModelInvoice
{
    public class MobileNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string mobileNumber = value as string;
            Regex regex = new Regex(@"^[6-9]\d{9}$");
            if (!string.IsNullOrWhiteSpace(mobileNumber))
                if (!regex.IsMatch(mobileNumber))
                    return new ValidationResult(false, "Mobile number is not valid");
            return ValidationResult.ValidResult;
        }
    }
}
