using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class SeatTableConfiguration : IEntityTypeConfiguration<SeatTable>
    {
        public void Configure(EntityTypeBuilder<SeatTable> builder)
        {
            builder.Property(x => x.Type)
                .IsRequired();
            builder.Property(x => x.Number)
                .IsRequired();
            builder.Property(x => x.isAvailable).HasDefaultValue(true);
            builder.Property(x => x.PlaceId).IsRequired();
            builder.HasMany(s => s.SeatTableReservation).WithOne(s => s.SeatTable).HasForeignKey(x => x.SeatTableId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
