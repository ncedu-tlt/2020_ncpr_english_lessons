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
                else
                {
                  db.Add(new Language { Title = "English" });
                  db.Add(new Language { Title = "Russian" });
                  db.Add(new Language { Title = "Espanol" });
                  db.Add(new Language { Title = "German" });
                  db.Add(new Language { Title = "French" });
                  db.SaveChanges();
                }

                if (db.Courses.Count() != 0)
                {
                    return;
                }
                else
                {
                    db.Add(new Course { 
                        CourseId = 1,
                        NumberOfVisits = 0,
                        Title = "Английский с нуля",
                        Requirements = "Никаких",
                        Description = "Последовательнное изучание основ языка",
                        Plan = "..."
                    });

                    db.Add(new Course
                    {
                        CourseId = 2,
                        NumberOfVisits = 0,
                        Title = "Основы разговорного английского",
                        Requirements = "Intermediate",
                        Description = "Учимся понимать собеседника, поддерживать разговор",
                        Plan = "..."
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
