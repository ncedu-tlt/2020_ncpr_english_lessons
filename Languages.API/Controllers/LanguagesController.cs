using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : Controller
    {
        [HttpGet]
        public ActionResult<List<Language>> GetLanguages()
        {
            using (var db = new DataBaseContext())
            {
                List<Language> languages = db.Languages
                    .OrderBy(b => b.LanguageId)
                    .ToList();
                   
                return languages;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Language> GetLanguageItem(long id)
        {
            using (var db = new DataBaseContext())
            {
                Language language = db.Languages
                    .Where(l => l.LanguageId == id)
                    .First();

                if (language == null)
                {
                    return NotFound();
                }

                return language;
            }
        }

        [HttpPost] // Create request 
        public ActionResult CreateLanguageItem([FromBody] Language language)
        {
            using (var db = new DataBaseContext())
            {
                bool languageIsAlreadyExists = db.Languages
                    .Where(l => l.Title.Equals(language.Title))
                    .Count() > 0;

                if (languageIsAlreadyExists)
                {
                    return Conflict(); // 409 Conflict
                }

                db.Add(language);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut] // Update request
        public ActionResult UpdateLanguageItem([FromBody] Language language)
        {
            using (var db = new DataBaseContext())
            {
                bool languageAlreadyExists = db.Languages
                    .Where(l => l.LanguageId.Equals(language.LanguageId))
                    .Count() > 0;

                if (languageAlreadyExists)
                {
                    db.Languages.Update(language);
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
        public ActionResult DeleteLanguageItem([FromBody] Language language)
        {
            using (var db = new DataBaseContext())
            {
                bool languageAlreadyExists = db.Languages
                    .Where(l => l.LanguageId.Equals(language.LanguageId))
                    .Count() > 0;

                if (languageAlreadyExists)
                {
                    db.Languages.Remove(language);
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

        [HttpDelete()] // Delete request 
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
