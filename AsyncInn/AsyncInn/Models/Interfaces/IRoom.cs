using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoom
    {
        // CREATE
        Task<Room> Create(Room Room);

        // GET ALL
        Task<List<RoomDTO>> GetAllRooms();

        // GET ONE BY ID
        Task<RoomDTO> GetRoom(int id);

        // UPDATE
        Task<Room> UpdateRoom(int id, Room room);

        // DELETE
        Task Delete(int id);

        // CREATE
        Task AddAmenityToRoom(int roomId, int amenityId);

        // DELETE
        Task RemoveAmenityFromRoom(int roomId, int amenityId);

    }
}
