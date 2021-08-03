﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTO
{
    public class HotelRoomDTO
    {
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public RoomDTO Room { get; set; }
    }
}
