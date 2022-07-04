using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EasieR.Domain;

namespace EasieR.DataAccess.Configurations
{
    class ReservationTypeConfiguration : IEntityTypeConfiguration<ReservationType>
    {
        public void Configure(EntityTypeBuilder<ReservationType> builder)
        {
            builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(30);
            builder.Property(x => x.MaxNumberOfGuests)
                 .IsRequired();
            builder.Property(x => x.EventId)
                 .IsRequired();
            builder.HasMany(s => s.Reservations).WithOne(r => r.ReservationType).HasForeignKey(x => x.ReservationTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(s => s.SeatTableReservationTypes).WithOne(r => r.ReservationType).HasForeignKey(x => x.ReservationTypeId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
