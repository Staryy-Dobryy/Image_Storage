using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublicationId { get; set; }
        public virtual User Author { get; set; }
        public virtual Publication Publication { get; set; }
    }
}