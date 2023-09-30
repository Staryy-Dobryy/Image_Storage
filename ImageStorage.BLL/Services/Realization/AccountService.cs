using AutoMapper;
using ImageStorage.BLL.Exceptions;
using ImageStorage.BLL.Exeptions;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.BLL.Tools;
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
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IMapper _mapper;
        private readonly HashTool _hashTool;
        public AccountService(IAccountRepository accountService, IUserRepository userRepository, IMapper mapper, IJwtAuthService jwtAuthService, HashTool hashTool)
        {
            _accountRepository = accountService;
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtAuthService = jwtAuthService;
            _hashTool = hashTool;
        }

        public async Task<string> CreateAccountAsync(CreateAccountModel source)
        {
            var user = await _userRepository.GetByEmailAsync(source.Email);

            if (user is not null)
            {
                throw new AccountAlreadyExistsException(source.Email);
            }

            var entity = _mapper.Map<Account>(source);

            var account = await _accountRepository.AddAndReturnAsync(entity);

            var jwtUserModel = _mapper.Map<JwtUserModel>(account.User);

            return _jwtAuthService.GenerateToken(jwtUserModel);

        }

        public async Task DeleteAccountAsync(Guid id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        public async Task<string> LoginToAccountAsync(AccountModel source)
        {
            var user = await _userRepository.GetByEmailWithDetailsAsync(source.Email);

            if (user is null)
            {
                throw new AccountDoesNotExistException(source.Email);
            }

            if (user.GoogleAuth)
            {
                throw new AccountUsesGoogleAuthException(source.Email);
            }

            if (user.Account.Password == _hashTool.HashPassword(source.Password))
            {
                var jwtUserModel = _mapper.Map<JwtUserModel>(user);

                return _jwtAuthService.GenerateToken(jwtUserModel);
            }

            throw new AccountLoginFailedException();
        }
    }
}
