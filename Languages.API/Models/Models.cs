using Microsoft.EntityFrameworkCore;
using System;

namespace Api.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Chat> ChatRooms { get; set; }
        //public DbSet<ChatMessages> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");
    }

    public class Language
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
    }

    public class Chat
    {
        public int ChatID { get; set; }
        public int ProfID { get; set; }
        public int StudID { get; set; }
    }

    public class ChatMessages
    {
        public int RecordID { get; set; }
        public static Chat IDs { get; set; }

        public int[] SenderID = { IDs.ProfID, IDs.StudID };
        public string SenderMessage { get; set; }
        public DateTime TimeWhenSent { get; set; }
    }
}
