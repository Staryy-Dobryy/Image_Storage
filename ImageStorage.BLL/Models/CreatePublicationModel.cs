using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Models
{
    public class CreatePublicationModel
    {
        public string Description { get; set; }
        public bool IsPublic { get; set; }
    }
}
