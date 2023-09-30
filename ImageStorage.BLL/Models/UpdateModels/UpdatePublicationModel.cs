using ImageStorage.BLL.Models.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Models.UpdateModels
{
    public class UpdatePublicationModel : CreatePublicationModel
    {
        public string Id { get; set; }
    }
}
