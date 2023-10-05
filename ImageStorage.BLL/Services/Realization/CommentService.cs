using AutoMapper;
using ImageStorage.BLL.Models;
using ImageStorage.BLL.Models.CreateModels;
using ImageStorage.BLL.Services.Interfaces;
using ImageStorage.DAL.Entities;
using ImageStorage.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Services.Realization
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentService, IMapper mapper)
        {
            _commentRepository = commentService;
            _mapper = mapper;
        }

        public async Task CreateCommentAsync(CreateCommentModel source, JwtUserModel jwtUser)
        {
            var comment = _mapper.Map<Comment>(source);
            comment.AuthorId = jwtUser.Id;
            comment.CreationTime = DateTime.Now;

            await _commentRepository.AddAsync(comment);
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            await _commentRepository.DeleteAsync(id);
        }
    }
}
