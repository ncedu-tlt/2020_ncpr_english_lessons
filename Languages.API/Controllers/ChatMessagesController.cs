using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessagesController : Controller
    {
        [HttpGet]
        public ActionResult<List<ChatMessages>> GetChatMessages()
        {
            using (var db = new DataBaseContext())
            {
                List<ChatMessages> Messages = db.Messages
                    .OrderBy(b => b.RecordID)
                    .ToList();
                return Messages;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<List<ChatMessages>> GetChatMessages(long id)
        {
            using (var db = new DataBaseContext())
            {
                List<ChatMessages> Messages = db.Messages.Where(i => i.Chat == id).ToList();
                if(db.Messages.Any(l => l.Chat == id))
                    return Messages;
                else
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult NewChatMessage ([FromBody] ChatMessages NewMessage)
        {
            using (var db = new DataBaseContext())
            {
                db.Messages.Add(NewMessage);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public ActionResult EditChatMessage ([FromBody] ChatMessages ToEdit)
        {
            using (var db = new DataBaseContext())
            {
                bool TheRightMessageToEdit = db.Messages.Where(l => l.RecordID.Equals(ToEdit.RecordID)).Count()>0;
                if (TheRightMessageToEdit)
                {
                    db.Messages.Update(ToEdit);
                    db.SaveChanges();
                    return Ok();
                }
                else
                    return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteChatMessage (long id)
        {
            using (var db = new DataBaseContext())
            {
                ChatMessages ForDeletion = db.Messages.Where(l => l.RecordID == id).First();
                bool Exists = db.Messages.Where(l => l.RecordID == id).Count() > 0;
                if (Exists)
                {
                    db.Messages.Remove(ForDeletion);
                    db.SaveChanges();
                    return Ok();
                }
                else
                return NotFound();
            }
        }

    }
}
