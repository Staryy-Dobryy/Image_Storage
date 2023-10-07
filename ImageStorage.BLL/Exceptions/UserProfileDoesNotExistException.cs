using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Exceptions
{
    public class UserProfileDoesNotExistException : Exception
    {
        public UserProfileDoesNotExistException() : base("This user profile does not exist") { }
    }
}
