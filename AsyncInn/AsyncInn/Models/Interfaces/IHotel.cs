using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        // CREATE
        Task<Hotel> Create(Hotel Hotel);

        // GET ALL
        Task<List<Hotel>> GetAllHotels();

        // GET ONE BY ID
        Task<Hotel> GetHotel(int id);

        // UPDATE
        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        // DELETE
        Task Delete(int id);
    }
}
