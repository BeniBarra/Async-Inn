using AsyncInn.Data;
using AsyncInn.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class RoomServices : IRoom
    {
        private AsyncInnDbContext _context;

        public RoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<List<Room>> GetAllRooms()
        {
            return await _context.Rooms
                                 .Include(r => r.HotelRooms)
                                 .ThenInclude(hR => hR.Hotel)
                                 .ToListAsync();
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            //return await _context.Rooms
            //                     .Include(r => r.HotelRooms)
            //                     .ThenInclude(hR => hR.Hotel)
            //                     .FirstOrDefaultAsync(h => h.Id == id);
            return await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.Name,
                    Layout = room.Layout
                }).FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<Room> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            RoomDTO room = await GetRoom(id);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = new RoomAmenities()
            {
                AmenityId = amenityId,
                RoomId = roomId
            };

            _context.Entry(roomAmenities).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            Room room = await _context.Rooms.FindAsync(roomId);
            List<Amenity> roomAmenities = room.RoomAmenities;
            for (int i = 0; i < roomAmenities.Count; i++)
            {
                if(roomAmenities[i].Id == amenityId)
                {
                    _context.Entry(roomAmenities[i]).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    break;
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
