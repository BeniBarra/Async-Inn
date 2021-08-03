using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room Room);

        Task<List<Room>> GetAllRooms();

        Task<RoomDTO> GetRoom(int id);

        Task<Room> UpdateRoom(int id, Room room);

        Task Delete(int id);

        Task AddAmenityToRoom(int roomId, int amenityId);

        Task RemoveAmenityFromRoom(int roomId, int amenityId);

    }
}
