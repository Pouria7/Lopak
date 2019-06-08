using System;
using System.Collections.Generic;
using System.Linq;
//using FluentValidation.Results;

namespace Lopak.Application.Exceptions
{
    public class LoginException : Exception
    {

        public LoginException()
            : base("Authentication error")
        {
            Failures = new LoginExceptionViewModel();
           
        }

        public LoginException(AutExMode Code)
            : this()
        {
            Failures.Code = (int)Code;
            if (Code == AutExMode.UsernameNotAvailable)
            {
                Failures.Message = "wrong username";
            }else if (Code == AutExMode.WrongPassword)
            {
                Failures.Message = "wrong username or password";
            }else if (Code == AutExMode.DisabledAccount)
            {
                Failures.Message = "account is disabled";
            }

        }

        public LoginExceptionViewModel Failures { get; }
    }

    public class LoginExceptionViewModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public enum AutExMode
    {
        UsernameNotAvailable = 1,
        WrongPassword = 2,
        DisabledAccount = 3
    }
}
