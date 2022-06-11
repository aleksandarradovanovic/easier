using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class PlaceStaffConfiguration : IEntityTypeConfiguration<PlaceStaff>
    {
        public void Configure(EntityTypeBuilder<PlaceStaff> builder)
        {
            builder.Property(x => x.PlaceId)
             .IsRequired();
            builder.Property(x => x.Position)
                 .IsRequired();
            builder.Property(x => x.UserId)
               .IsRequired();
        }
    }
}
