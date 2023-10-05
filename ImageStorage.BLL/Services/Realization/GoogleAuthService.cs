using AutoMapper;
using ImageStorage.BLL.Models;
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
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthService _jwtAuthService;
        private readonly IMapper _mapper;

        public GoogleAuthService(IUserRepository userRepository, IJwtAuthService jwtAuthService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtAuthService = jwtAuthService;
            _mapper = mapper;
        }

        public async Task<string> LoginByGoogleAccountAsync(GoogleAuthModel source)
        {
            var user = await _userRepository.GetByEmailAsync(source.Email);

            if (user is null)
            {
                var entity = _mapper.Map<User>(source);

                var createdUser = await _userRepository.AddAndReturnAsync(entity);

                var jwtUserModel = _mapper.Map<JwtUserModel>(createdUser);

                return _jwtAuthService.GenerateToken(jwtUserModel);
            }

            return _jwtAuthService.GenerateToken(_mapper.Map<JwtUserModel>(user));
        }
    }
}
