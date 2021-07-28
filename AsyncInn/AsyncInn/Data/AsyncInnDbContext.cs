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
        public AsyncInnDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
