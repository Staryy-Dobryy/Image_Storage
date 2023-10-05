using ImageStorage.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface IJwtAuthService
    {
        string GenerateToken(JwtUserModel source);
    }
}
