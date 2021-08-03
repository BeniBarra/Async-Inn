using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
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
            // base.OnModelCreating(modelBuilder);

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
                      Id = 2,
                      Name = "Amenities 1",
                  }
                );
            modelBuilder.Entity<Room>().HasData(
                  new Room
                  {
                      Id = 3,
                      Name = "Room 1",
                      Layout = "2 Rooms"
                  }
                );
            modelBuilder.Entity<HotelRoom>().HasData(
                  new HotelRoom
                  {
                      HotelId = 1,
                      RoomId = 3,
                      RoomNumber = 1
                  }
                );
            modelBuilder.Entity<RoomAmenities>().HasKey(
                roomAmenities => new { roomAmenities.AmenityId, roomAmenities.RoomId }
                );
            modelBuilder.Entity<HotelRoom>().HasKey(
                hotelRoom => new { hotelRoom.HotelId, hotelRoom.RoomId }
                );
        }
    }
}
