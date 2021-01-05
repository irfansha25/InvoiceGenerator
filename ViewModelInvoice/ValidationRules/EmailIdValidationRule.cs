using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ViewModelInvoice
{
    public class EmailIdValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string emailId = value as string;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!string.IsNullOrWhiteSpace(emailId))
                if (!regex.IsMatch(emailId))
                    return new ValidationResult(false, "Email Id is not valid");
            return ValidationResult.ValidResult;
        }
    }
}
