using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace saitynai_server.Data
{
    public class TablegamesContext : IdentityDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = File.ReadAllText("connectionString.txt");
                optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
            }
        }
    }
}
