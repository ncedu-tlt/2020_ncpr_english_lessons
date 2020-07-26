using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            using (var db = new DataBaseContext())
            {
                List<User> users = db.Users
                    .OrderBy(b => b.UserId)
                    .ToList();

                return users;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserItem(long id)
        {
            using (var db = new DataBaseContext())
            {
                User user = db.Users
                    .Where(l => l.UserId == id)
                    .First();

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
        }

        [HttpPost] 
        public ActionResult CreateUserItem([FromBody] User user)
        {
            using (var db = new DataBaseContext())
            {
                bool userIsAlreadyExists = db.Users
                    .Where(l => l.Login.Equals(user.Login))
                    .Count() > 0;

                if (userIsAlreadyExists)
                {
                    return Conflict(); // 409 Conflict
                }

                db.Add(user);
                db.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public ActionResult UpdateUserItem([FromBody] User user)
        {
            using (var db = new DataBaseContext())
            {
                bool userAlreadyExists = db.Users
                    .Where(l => l.UserId.Equals(user.UserId))
                    .Count() > 0;

                if (userAlreadyExists)
                {
                    db.Users.Update(user);
                    db.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

        [HttpDelete("{id}")] 
        public ActionResult<User> DeleteuserItem(long id)
        {
            using (var db = new DataBaseContext())
            {
                bool UserLanguageExists = db.Users.Any(l => l.UserId == id);

                if (UserLanguageExists)
                {
                    db.Users.RemoveRange(db.Users.Where(l => l.UserId == id));
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
