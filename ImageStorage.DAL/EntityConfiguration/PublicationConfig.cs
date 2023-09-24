using ImageStorage.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageStorage.DAL.EntityConfiguration
{
    public class PublicationConfig : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.HasIndex(x => x.Id);

            builder
                .HasMany(x => x.Comments)
                .WithOne(x => x.Publication)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.PublicationId);
        }
    }
}
