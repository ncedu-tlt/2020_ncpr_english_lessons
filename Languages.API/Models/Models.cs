using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=database.db");
    }

    public class Language
    {
        public int LanguageId { get; set; }
        public string Title { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Поле для хранения хэша пароля.
        /// </summary>
        public string HashPassword { get; set; }

        /// <summary>
        /// "Соль", которая хранит рандомное значение.
        /// Алгоритм хэширования получает на вход пароль и "соль", а выдает хэш пароля.
        /// Таким образом, пользователи с одинаковыми паролями будут иметь разные хэши паролей.
        /// </summary>
        public string Sault { get; set; }        

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
    }
}
