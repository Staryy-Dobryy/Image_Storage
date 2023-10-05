using AutoMapper;
using ImageStorage.BLL.Models;
using ImageStorage.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.BLL.Mapping
{
    internal class CommentModelWithUserConverter : ITypeConverter<Comment, CommentModel>
    {
        public CommentModel Convert(Comment source, CommentModel destination, ResolutionContext context)
        {
            if (destination is null) destination = new CommentModel();

            destination.Text = source.Text;
            destination.CreationTime = source.CreationTime;
            destination.Author = new()
            {
                Id = source.Author.Id.ToString(),
                UserName = source.Author.Name,
                ImageUrl = source.Author.ImageUrl
            };

            return destination;
        }
    }
}
