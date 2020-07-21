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

                if (db.Users.Count() != 0)
                {
                    return;
                }
                else
                {
                    db.Add(new User { 
                        Login = "fox",
                        Email = "fox@gmail.com",
                        HashPassword = "2131asdasdff$123##",
                        Sault = "22",
                        Name = "Moses",
                        Surname = "Samoilov",
                        Patronymic = "Borisovich"

                    });

                    db.Add(new User
                    {
                        Login = "wolf",
                        Email = "wolf@gmail.com",
                        HashPassword = "87ds8dsfsd22123451",
                        Sault = "51",
                        Name = "Matvey",
                        Surname = "Orlov",
                        Patronymic = "Valentinovich"

                    });

                    db.Add(new User
                    {
                        Login = "cat",
                        Email = "cat@gmail.com",
                        HashPassword = "8435787s#asdahhxc",
                        Sault = "11",
                        Name = "Ada",
                        Surname = "Alexandrova",
                        Patronymic = "Boguslavovna"

                    });

                    db.Add(new User
                    {
                        Login = "mouse",
                        Email = "mouse@gmail.com",
                        HashPassword = "00213xvxsd&&asd23",
                        Sault = "4",
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
