using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ViewInvoice;

namespace ViewModelInvoice
{
    public class ClientNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string clientName = value as string;
            if (string.IsNullOrWhiteSpace(clientName))
                return new ValidationResult(false, "Client Name is Empty");
            else
            {
                Client objClient = new VMClient().GetClientFromName(clientName);
                if (objClient.ClientId > 0)
                    return new ValidationResult(false, "Client already exist");
                else
                    return ValidationResult.ValidResult;
            }
        }
    }
}
