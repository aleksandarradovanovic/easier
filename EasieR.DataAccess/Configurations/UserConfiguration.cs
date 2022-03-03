using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasieR.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.UserName).IsUnique();
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(40);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(30);
            builder.HasMany(u => u.UserRoles).WithOne(ur => ur.User).HasForeignKey(x =>x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(u => u.Reservations).WithOne(ur => ur.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
