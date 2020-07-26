using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Chat> ChatRooms { get; set; }
        public DbSet<ChatMessages> Messages { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }


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
        [Key]
        public int RecordID { get; set; }

        public int Chat { get; set; }
        public bool IsProf { get; set; }
        public int Sender { get; set; }
        public string SenderMessage { get; set; }
        public DateTime TimeWhenSent { get; set; }

    public class Course
    {
        public int CourseId { get; set; }
        public int NumberOfVisits { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
    }
  
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }      

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}

