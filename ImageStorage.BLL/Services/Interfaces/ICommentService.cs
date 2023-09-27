using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync();
        Task DeleteCommentAsync(Guid id);
    }
}
