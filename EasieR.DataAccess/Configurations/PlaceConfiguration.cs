using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class PlaceConfiguration : IEntityTypeConfiguration<Place>
    {
        public void Configure(EntityTypeBuilder<Place> builder)
        {
            builder.Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(30);
            builder.Property(x => x.Type)
                 .IsRequired()
                 .HasMaxLength(30);
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(100);
            builder.Property(x => x.StartWorkingTime)
               .IsRequired();
            builder.Property(x => x.EndWorkingTime)
              .IsRequired();
            builder.HasMany(e => e.Events).WithOne(p => p.Place).HasForeignKey(x => x.PlaceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.SeatTables).WithOne(p => p.Place).HasForeignKey(x => x.PlaceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Staff).WithOne(p => p.Place).HasForeignKey(x => x.PlaceId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Images).WithOne(p => p.Place).HasForeignKey(x => x.PlaceId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
