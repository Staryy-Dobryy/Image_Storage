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
            if (destination is null) destination = new Account();

            destination.Email = source.Email;
            destination.Password = source.Password;

            // UserId for relation
            destination.UserId = Guid.NewGuid();
            destination.User = new()
            {
                // Id for relation
                Id = (Guid)destination.UserId,
                Email = source.Email,
                Name = source.Name,
                GoogleAuth = false,
                ImageUrl = "/Images/baseUserImg.png"
            };

            return destination;
        }
    }
}
