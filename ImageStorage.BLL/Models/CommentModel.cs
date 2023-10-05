using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Models
{
    public class CommentModel
    {
        public string Text { get; set; }
        public UserModel Author { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
