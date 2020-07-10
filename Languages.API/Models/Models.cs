using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");
    }

    public class Language
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
    }
}
