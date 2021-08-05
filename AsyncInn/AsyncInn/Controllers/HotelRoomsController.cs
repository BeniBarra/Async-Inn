using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTO;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms()
        {
            var list = await _hotelRoom.GetHotelRooms();
            return Ok(list);
        }

        // GET: api/HotelRooms/5
        [HttpGet("Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int hotelId, int roomId)
        {
            HotelRoomDTO hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomId);
            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomId, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelId || roomId != hotelRoom.RoomId)
            {
                return BadRequest();
            }
            var updateHotelRoom = await _hotelRoom.UpdateHotelRoom(hotelId, roomId, hotelRoom);
            return Ok(updateHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            await _hotelRoom.Create(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelId, hotelRoom.RoomId }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("Hotels/{hotelId}/Rooms/{roomId}")]
        public async Task<IActionResult> DeleteHotelRoom(int id)
        {
            await _hotelRoom.Delete(id);
            return NoContent();
        }

    }
}
