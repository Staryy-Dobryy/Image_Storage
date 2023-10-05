using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Entities
{
    public class Account : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
