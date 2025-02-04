﻿using AsyncInn.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenity
    {
        // CREATE
        Task<Amenity> Create(AmenityDTO amenity);

        // GET ALL
        Task<List<AmenityDTO>> GetAllAmenities();

        // GET ONE BY ID
        Task<AmenityDTO> GetAmenity(int id);

        // UPDATE
        Task<Amenity> UpdateAmenity(int id, Amenity amenity);

        // DELETE
        Task Delete(int id);

    }
}
