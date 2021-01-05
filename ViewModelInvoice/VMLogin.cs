using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewInvoice;
namespace ViewModelInvoice
{
    public class VMLogin
    {
        public bool CheckUserName(string userName, string password)
        {
            string query = "Select count(0) from UserMaster where UserName='" + userName + "' And Password='" + password + "'";
            object userExist = Common.ExecuteScalar(query);
            if (userExist != null)
            {
                Common.UserId = Convert.ToInt32(userExist);
                VMSetting vmsetting = new VMSetting();
                Common.GeneralSetting = vmsetting.GetSetting();
                vmsetting.LoadCoordinates();
                return Common.UserId > 0 ? true : false;
            }
            return false;
        }
        public string ValidateCredentials(string userName,string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return "User name should not be empty";
            else if (string.IsNullOrWhiteSpace(password))
                return "password should not be empty";
            else
                return string.Empty;
        }
    }
    public class CustomError
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }

        public CustomError(bool isError, string errorMessage)
        {
            IsError = isError;
            ErrorMessage = errorMessage;
        }

    }
}
