using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(40);
            builder.Property(x => x.StreetAndNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Latitude)
               .HasColumnType("decimal(8,6)");
            builder.Property(x => x.Longitude)
               .HasColumnType("decimal(9,6)");
        }
    }
}
