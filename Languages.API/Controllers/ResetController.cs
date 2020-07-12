using Api.Migrations;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetController : Controller
    {
        [HttpGet]
        [System.Obsolete]
        public void Reset()
        {
            using (var db = new DataBaseContext())
            {
                _ = db.Database.ExecuteSqlCommand("DELETE FROM Languages");
                _ = db.Database.ExecuteSqlCommand("DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Languages'");
                InitialDataBaseContent.Create();
            }
        }
    }
}
