﻿using ImageStorage.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.Repositories.Interfaces
{
    public interface IViewRepository
    {
        Task<bool> PublicationViewedByUserIdAsync(Guid publicationId, Guid userId);
        Task AddViewedPublicationByUserIdAsync(View viewObject);
    }
}
