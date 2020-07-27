using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomsController : Controller
    {
        [HttpGet]
        public ActionResult<List<Chat>> GetChatRooms()
        {
            using (var db = new DataBaseContext())
            {
                List<Chat> Rooms = db.ChatRooms
                    .OrderBy(b => b.ChatID)
                    .ToList();

                return Rooms;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Chat> GetChatRoom(long id)
        {
            using (var db = new DataBaseContext())
            {
                Chat ChatRoom = db.ChatRooms
                    .Where(l => l.ChatID == id)
                    .First();

                if (ChatRoom == null)
                {
                    return NotFound();
                }

                return ChatRoom;
            }
        }

        [HttpPost] // Create request 
        public ActionResult CreateChatRoom([FromBody] Chat ChatRoom)
        {
            using (var db = new DataBaseContext())
            {
                bool ChatRoomAlreadyExists = db.ChatRooms
                    .Where(l => l.ChatID.Equals(ChatRoom.ChatID))
                    .Count() > 0;

                if (ChatRoomAlreadyExists)
                {
                    return Conflict(); // 409 Conflict
                }

                db.Add(ChatRoom);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut] // Update request
        public ActionResult UpdateLanguageItem([FromBody] Chat ChatRoom)
        {
            using (var db = new DataBaseContext())
            {
                bool ChatRoomAlreadyExists = db.ChatRooms
                    .Where(l => l.ChatID.Equals(ChatRoom.ChatID))
                    .Count() > 0;

                if (ChatRoomAlreadyExists)
                {
                    db.ChatRooms.Update(ChatRoom);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }


            }
        }

        [HttpDelete] // Delete request 
        public ActionResult DeleteLanguageItem([FromBody] Chat ChatRoom)
        {
            using (var db = new DataBaseContext())
            {
                bool ChatRoomAlreadyExists = db.ChatRooms
                    .Where(l => l.ChatID.Equals(ChatRoom.ChatID))
                    .Count() > 0;

                if (ChatRoomAlreadyExists)
                {
                    db.ChatRooms.Remove(ChatRoom);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }


            }
        }


    }
}
