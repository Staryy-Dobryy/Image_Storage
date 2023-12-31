﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Models
{
    public class PublicationModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Views { get; set; }
        public UserModel Author { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}
