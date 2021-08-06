using AsyncInn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel
                    {
                        Id = 1,
                        Name = "Async Inn",
                        StreetAddress = "42nd and Broadway",
                        City = "New York",
                        State = "New York",
                        Country = "US",
                        Phone = "917-555-1234"
                    }
                );
            modelBuilder.Entity<Amenity>().HasData(
                  new Amenity
                  {
                      Id = 1,
                      Name = "Amenities 1",
                  }
                );
            modelBuilder.Entity<Room>().HasData(
                  new Room
                  {
                      Id = 1,
                      Name = "Room 1",
                      Layout = "2 Rooms"
                  }
                );
            modelBuilder.Entity<HotelRoom>().HasData(
                  new HotelRoom
                  {
                      HotelId = 1,
                      RoomId = 1,
                  }
                );
            modelBuilder.Entity<RoomAmenities>().HasKey(
                roomAmenities => new { roomAmenities.AmenityId, roomAmenities.RoomId }
                );
            modelBuilder.Entity<HotelRoom>().HasKey(
                hotelRoom => new { hotelRoom.HotelId, hotelRoom.RoomId }
                );

            SeedRole(modelBuilder, "Administrator", "create", "update", "delete");
            SeedRole(modelBuilder, "Manager", "create", "update");
            SeedRole(modelBuilder, "Supervisor", "create");
        }

        private int nextId = 1;
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions", // This matches what we did in Startup.cs
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }

    }
}
