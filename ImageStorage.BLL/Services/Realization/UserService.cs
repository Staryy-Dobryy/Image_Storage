using AutoMapper;
using ImageStorage.BLL.Exceptions;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.UpdateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.BLL.Tools;
using ImageStorage.DAL.Repositories.Interfaces;
using ImageStorage.DAL.Repositories.Realization;
using Microsoft.AspNetCore.Http;
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
        private readonly ImageHandlerTool _imageHandlerTool;

        public UserService(IUserRepository userRepository, IMapper mapper, ImageHandlerTool saveImageTool)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _imageHandlerTool = saveImageTool;
        }

        public async Task<UserModel?> GetUserProfileByIdAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
            {
                throw new UserProfileDoesNotExistExcaption();
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task SaveUserImageAsync(IFormFile image, string webRootPath, string imageUrl)
        {
            await _imageHandlerTool.SaveImageAsync(image, webRootPath, imageUrl);
        }

        public async Task UpdateUserInfoAsync(UpdateUserModel source, JwtUserModel jwtUser, string webRootPath = null)
        {
            var oldUser = await _userRepository.GetByIdAsync(jwtUser.Id);

            if (!string.IsNullOrEmpty(webRootPath))
            {
                _imageHandlerTool.DeleteImage(webRootPath, oldUser.ImageUrl);
            }

            var newUser = _mapper.Map(source, oldUser);

            await _userRepository.UpdateAsync(newUser);
        }
    }
}
