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
    public class PublicationModelConverter : ITypeConverter<Publication, PublicationModel>
    {
        public PublicationModel Convert(Publication source, PublicationModel destination, ResolutionContext context)
        {
            if (destination is null) destination = new PublicationModel();

            destination.Id = source.Id.ToString();
            destination.Discription = source.Description;
            destination.ImageUrl = source.ImageUrl;
            destination.Views = source.ViewsCount;
            destination.Author = context.Mapper.Map<UserModel>(source.Author);
            
            if (source.Comments is null)
            {
                return destination;
            }

            destination.Comments = new(source.Comments.Count);

            foreach (var comment in source.Comments)
            {
                var mappedComment = context.Mapper.Map<CommentModel>(comment);

                destination.Comments.Add(mappedComment);
            }

            return destination;
        }
    }
}
