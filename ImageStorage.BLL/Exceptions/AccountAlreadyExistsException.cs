using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Exeptions
{
    public class AccountAlreadyExistsException : Exception
    {
        public AccountAlreadyExistsException(string email) : base($"Account with \"{email}\" email already exists.") { }
    }
}
