using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Exeptions
{
    public class AccountDoesNotExistException : Exception
    {
        public AccountDoesNotExistException(string email) : base($"Account with \"{email}\" email does not exist.") { }
    }
}
