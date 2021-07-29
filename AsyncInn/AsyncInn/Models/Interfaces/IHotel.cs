using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> Create(Hotel Hotel);

        Task<List<Hotel>> GetAllHotels();

        Task<Hotel> GetHotel(int id);

        Task<Hotel> UpdateHotel(int id, Hotel hotel);

        Task Delete(int id);
    }
}
