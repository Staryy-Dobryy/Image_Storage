using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Exceptions
{
    public class AccountLoginFailedException : Exception
    {
        public AccountLoginFailedException() : base("Login to account failed.") { }
    }
}
