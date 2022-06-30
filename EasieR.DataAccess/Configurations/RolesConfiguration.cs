using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();
            builder.HasMany(r => r.ActorRoles).WithOne(ur => ur.Roles).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
