using AsyncInn.Data;
using AsyncInn.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class HotelRoomServices : IHotelRoom
    {
        private AsyncInnDbContext _context;
        public HotelRoomServices(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> Create(HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomId)
        {
            //HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(id);
            //return hotelRoom;
            return await _context.HotelRooms
                .Select(hotelRooms => new HotelRoomDTO
                {
                    HotelId = hotelRooms.HotelId,
                    RoomId = hotelRooms.RoomId,
                    Room = hotelRooms.Room.HotelRooms
                        .Select(r => new RoomDTO
                    {
                        ID = r.Room.Id,
                        Name = r.Room.Name,
                        Layout = r.Room.Layout,
                        Amenities = r.Room.RoomAmenities
                            .Select(ra => new AmenityDTO
                            {
                                Id = ra.Id,
                                Name = ra.Name
                            }).ToList()
                    }).FirstOrDefault( r => r.ID == roomId)
                }).FirstOrDefaultAsync(hr => hr.HotelId == hotelId && hr.RoomId == roomId);
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            //var hotelRooms = await _context.HotelRooms.ToListAsync();
            //return hotelRooms;
            return await _context.HotelRooms
                .Select(hotelRooms => new HotelRoomDTO
                {
                    HotelId = hotelRooms.HotelId,
                    RoomId = hotelRooms.RoomId,
                    Room = new RoomDTO
                    {
                        ID = hotelRooms.Room.Id,
                        Name = hotelRooms.Room.Name,
                        Layout = hotelRooms.Room.Layout
                    }
                }).ToListAsync();
        }

        public async Task<HotelRoom> UpdateHotelRoom(int id, int roomNumber, HotelRoom hotelRoom)
        {
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }

        public async Task Delete(int id)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(id);
            _context.Entry(hotelRoom).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
