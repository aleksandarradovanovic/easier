using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.Property(x => x.NameOn)
                 .IsRequired()
                 .HasMaxLength(30);
            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(x => x.NumberOfGuests)
                 .IsRequired()
                 .HasMaxLength(10);
            builder.Property(x => x.ReservationTypeId)
                 .IsRequired();
            builder.HasMany(s => s.SeatTableReservation).WithOne(r => r.Reservation).HasForeignKey(x => x.ReservationId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
