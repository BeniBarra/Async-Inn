using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom);

        Task<List<HotelRoom>> GetHotelRooms();

        Task<HotelRoomDTO> GetHotelRoom(int id);

        Task<HotelRoom> UpdateHotelRoom(int id, int roomNumber, HotelRoom hotelRoom);

        Task Delete(int id);
    }
}
