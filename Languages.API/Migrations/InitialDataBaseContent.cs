using Api.Models;
using Microsoft.VisualBasic;
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
                    //return;
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
                if (db.ChatRooms.Count() != 0)
                {

                }
                else
                {
                    db.Add(new Chat { ProfID = 1, StudID = 23 });
                    db.Add(new Chat { ProfID = 32, StudID = 23 });
                    db.Add(new Chat { ProfID = 1, StudID = 43 });
                    db.Add(new Chat { ProfID = 32, StudID = 43 });
                    db.SaveChanges();
                }
                if (db.Messages.Count() != 0)
                {

                }
                else
                {
                    db.Add(new ChatMessages { Chat = 0, IsProf = true, Sender = 1, SenderMessage = "Howdy, partner", TimeWhenSent = DateAndTime.Now });
                    db.Add(new ChatMessages { Chat = 0, IsProf = false, Sender = 23, SenderMessage = "Sup, Professor", TimeWhenSent = DateAndTime.Now });
                    db.SaveChanges();
                }
            }
        }
    }
}
