using AutoMapper;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.UpdateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.DAL.Repositories.Interfaces;
using ImageStorage.DAL.Repositories.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Realization
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task UpdateUserInfoAsync(UpdateUserModel source, JwtUserModel jwtUser)
        {
            var oldUser = await _userRepository.GetByIdAsync(jwtUser.Id);
            var newUser = _mapper.Map(source, oldUser);

            await _userRepository.UpdateAsync(newUser);
        }
    }
}
