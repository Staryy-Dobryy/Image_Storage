using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public bool GoogleAuth { get; set; }
        public Guid AccountId { get; set; }
        public virtual Account Account { get; set; }    
    }
}
