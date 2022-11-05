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
                //optionsBuilder.UseNpgsql(_configuration.GetValue<string>("PostgreSQLConnectionString"));
                //optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"));
                string connString = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
                if(connString == null)
                    optionsBuilder.UseSqlServer(_configuration["AZURE_SQL_CONNECTIONSTRING"]);
            }
        }
    }
}
