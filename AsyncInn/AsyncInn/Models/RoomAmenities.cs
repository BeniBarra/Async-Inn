﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenityId { get; set; }

        public int RoomId { get; set; }

        //Navigation properties
        public Amenity Amenity { get; set; }

        public Room Room { get; set; }
    }
}
