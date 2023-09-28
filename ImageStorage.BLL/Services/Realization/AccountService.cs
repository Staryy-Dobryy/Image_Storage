using AutoMapper;
using ImageStorage.BLL.Exeptions;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Realization
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountService, IUserRepository userRepository, IMapper mapper)
        {
            _accountRepository = accountService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateAccountAsync(CreateAccountModel sourse)
        {
            var user = await _userRepository.GetByEmailAsync(sourse.Email);

            if (user is not null)
            {
                throw new AccountAlreadyExistsExeption(sourse.Email);
            }

            /* TODO: Create mapping. Return new JWT;
            var entity = _mapper.Map<Account>(sourse);

            await _accountRepository.AddAsync(entity);

            return "JWTsecurityToken";*/

        }

        public async Task DeleteAccountAsync(Guid id)
        {
            await _accountRepository.DeleteAsync(id);
        }
    }
}
