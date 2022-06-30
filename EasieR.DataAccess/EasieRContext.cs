using EasieR.DataAccess.Configurations;
using EasieR.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace EasieR.DataAccess
{
    public class EasieRContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new SeatTableConfiguration());
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceStaffConfiguration());

            modelBuilder.Entity<ActorRoles>().HasKey(x => new { x.ActorId, x.RoleId });
            modelBuilder.Entity<SeatTableReservation>().HasKey(x => new { x.ReservationId, x.SeatTableId });
            modelBuilder.Entity<Actor>().HasData(InitData.CreateActors());
            modelBuilder.Entity<Roles>().HasData(InitData.CreateRoles());
            modelBuilder.Entity<ActorRoles>().HasData(InitData.CreateActorRoles());
            modelBuilder.Entity<User>().HasData(InitData.CreateAdminUser());


        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.isActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.isDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS;Initial Catalog = easieRDatabase; Integrated Security = SSPI;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<SeatTable> SeatTable { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<PlaceStaff> PlaceStaff { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<Actor> Actor { get; set; }


    }
}
