using AsyncInn.Data;
using AsyncInn.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class AmenityServices : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(AmenityDTO inBoundAmenity)
        {
            Amenity amenity = new Amenity()
            {
                Id = inBoundAmenity.Id,
                Name = inBoundAmenity.Name
            };
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;
        }

        public async Task<List<AmenityDTO>> GetAllAmenities()
        {
            //var amenities = await _context.Amenities.ToListAsync();
            //return amenities;
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                }).ToListAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            //Amenity amenity = await _context.Amenities.FindAsync(id);
            //return amenity;
            return await _context.Amenities
                .Select(amenity => new AmenityDTO
                {
                    Id = amenity.Id,
                    Name = amenity.Name
                }).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Amenity> UpdateAmenity(int id, Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task Delete(int id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(id);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
