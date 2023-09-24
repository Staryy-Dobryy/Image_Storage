using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Entities
{
    public class Publication : BaseEntity
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ViewsCount { get; set; }
        public bool IsPublic { get; set; }
        public Guid AuthorId { get; set; }  
        public virtual User Author { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
