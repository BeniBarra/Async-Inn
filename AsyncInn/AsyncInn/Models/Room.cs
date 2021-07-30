using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Room
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Layout { get; set; }

                //Navigation properties
        public List<Amenity> Amenity { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
