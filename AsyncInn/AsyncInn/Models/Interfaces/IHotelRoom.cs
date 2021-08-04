using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        // CREATE
        Task<HotelRoom> Create(HotelRoom hotelRoom);

        // GET ALL
        Task<List<HotelRoomDTO>> GetHotelRooms();

        // GET ONE BY ID
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomId);

        // UPDATE
        Task<HotelRoom> UpdateHotelRoom(int id, int roomNumber, HotelRoom hotelRoom);

        // DELETE
        Task Delete(int id);
    }
}
