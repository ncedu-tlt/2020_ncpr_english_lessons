using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");
    }

    public class Language
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public int NumberOfVisits { get; set; }
        public string Title { get; set; }
        public string Requirements { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
    }
}
