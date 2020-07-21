using System;
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

        [HttpDelete("{id}")] // Delete request 
        public ActionResult<Language> DeleteLanguageItem(long id)
        {
            using (var db = new DataBaseContext())
            {
                bool LanguageExists = db.Languages.Any(l => l.LanguageId == id);

                if (LanguageExists)
                {
                    db.Languages.RemoveRange(db.Languages.Where(l => l.LanguageId == id));
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
