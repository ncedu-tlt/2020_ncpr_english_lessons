using Api.Models;
using System.Linq;

namespace Api.Migrations
{
    public class InitialDataBaseContent
    {
        public static void Create() 
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                db.Database.EnsureCreated();
                if (db.Languages.Count() != 0) 
                {
                    return;
                }
                db.Add(new Language { Title = "English" });
                db.Add(new Language { Title = "Russian" });
                db.Add(new Language { Title = "Espanol" });
                db.Add(new Language { Title = "German" });
                db.Add(new Language { Title = "French" });
                db.SaveChanges();
            }
        }
    }
}
