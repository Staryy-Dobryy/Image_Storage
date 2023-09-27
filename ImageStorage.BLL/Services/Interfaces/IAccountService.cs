using ImageStorage.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateAccountAsync(CreateAccountModel sourse);
        Task DeleteAccountAsync(Guid id);
    }
}
