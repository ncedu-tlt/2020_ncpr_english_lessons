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
        public JsonResult Get()
        {
            using (var db = new DataBaseContext())
            {
                List<Language> languages = db.Languages
                    .OrderBy(b => b.LanguageId)
                    .ToList();
                   
                return Json(languages); ;
            }
        }

        [HttpPost("{title}")]
        public ActionResult Get(string title)
        {
            using (var db = new DataBaseContext())
            {
                bool languageIsAlreadyExists = db.Languages
                    .Where(l => l.Title.Equals(title))
                    .Count() > 0;

                if (languageIsAlreadyExists) 
                {
                    return Conflict(); // 409 Conflict
                }

                db.Add(new Language { Title = title });
                db.SaveChanges();

                return Ok();
            }
        }
    }
}
