using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Tools
{
    public class HashTool
    {
        private readonly IConfiguration _configuration;

        public HashTool(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string HashPassword(string password)
        {
            var salt = Encoding.UTF8.GetBytes(_configuration["Secret"]);

            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 16,
            numBytesRequested: 256 / 8));

            return hashedPassword;
        }
    }
}
