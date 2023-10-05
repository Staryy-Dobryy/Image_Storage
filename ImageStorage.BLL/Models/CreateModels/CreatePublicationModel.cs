using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Models.CreateModels
{
    public class CreatePublicationModel
    {
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPublic { get; set; }
    }
}
