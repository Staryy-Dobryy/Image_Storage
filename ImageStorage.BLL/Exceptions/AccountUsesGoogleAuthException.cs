using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Exceptions
{
    public class AccountUsesGoogleAuthException : Exception
    {
        public AccountUsesGoogleAuthException(string email) : base($"Account with \"{email}\" email uses google authentication.") { }
    }
}
