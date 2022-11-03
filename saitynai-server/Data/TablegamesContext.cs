using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace saitynai_server.Data
{
    public class TablegamesContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Advertisement> Advertisements { get; set; } = null!;

        public TablegamesContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql(_configuration.GetValue<string>("MySQLConnectionString"), ServerVersion.Parse("5.7.36-mysql"));
                optionsBuilder.UseMySql("server = localhost; port = 3306; database = saitynai; uid = root; pwd =;", ServerVersion.Parse("5.7.36-mysql"));
            }
        }
    }
}
