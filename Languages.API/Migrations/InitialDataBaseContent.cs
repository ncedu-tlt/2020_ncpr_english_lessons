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


                if (db.Users.Count() != 0)
                {
                    return;
                }
                else
                {
                    db.Add(new User { 
                        Login = "fox",
                        Email = "fox@gmail.com",
                        Password = "2131asdasdff$123##",
                        Name = "Moses",
                        Surname = "Samoilov",
                        Patronymic = "Borisovich"

                    });

                    db.Add(new User
                    {
                        Login = "wolf",
                        Email = "wolf@gmail.com",
                        Password = "87ds8dsfsd22123451",
                        Name = "Matvey",
                        Surname = "Orlov",
                        Patronymic = "Valentinovich"

                    });

                    db.Add(new User
                    {
                        Login = "cat",
                        Email = "cat@gmail.com",
                        Password = "8435787s#asdahhxc",
                        Name = "Ada",
                        Surname = "Alexandrova",
                        Patronymic = "Boguslavovna"

                    });

                    db.Add(new User
                    {
                        Login = "mouse",
                        Email = "mouse@gmail.com",
                        Password = "00213xvxsd&&asd23",
                        Name = "Olga",
                        Surname = "Gordeeva",
                        Patronymic = "Vsevolodovna"
                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
