using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateAccountAsync(CreateAccountModel source);
        Task<string> LoginToAccountAsync(AccountModel source);
        Task DeleteAccountAsync(Guid id);
    }
}
