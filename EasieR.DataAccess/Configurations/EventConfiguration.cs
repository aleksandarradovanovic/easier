using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Name)
             .IsRequired()
             .HasMaxLength(30);
            builder.Property(x => x.Type)
             .IsRequired()
             .HasMaxLength(20);
            builder.Property(x => x.Description)
             .IsRequired()
             .HasMaxLength(100);
            builder.Property(x => x.PlaceId)
             .IsRequired();
            builder.Property(x => x.StartTime)
             .IsRequired();
            builder.Property(x => x.EndTime)
            .IsRequired();

            builder.HasMany(r => r.Reservations).WithOne(e => e.Event).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(i => i.EventImages).WithOne(e => e.Event).HasForeignKey(x => x.EventId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
