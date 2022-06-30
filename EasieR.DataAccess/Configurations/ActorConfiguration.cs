using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasMany(r => r.ActorRoles).WithOne(ur => ur.Actor).HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(e => e.Users).WithOne(u => u.Actor).HasForeignKey(x=>x.ActorId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
