using AutoMapper;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Mapping
{
    public class CreateAccountWithUserConverter : ITypeConverter<CreateAccountModel, Account>
    {
        public Account Convert(CreateAccountModel source, Account destination, ResolutionContext context)
        {
            destination.Email = source.Email;
            destination.Password = source.Password;
            destination.User = new()
            {
                Email = source.Email,
                Name = source.Name,
                GoogleAuth = false,
                ImageUrl = "/default-image.png"
            };

            return destination;
        }
    }
}
