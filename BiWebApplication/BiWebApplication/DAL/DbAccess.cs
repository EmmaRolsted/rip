using BiWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BiWebApplication.DAL
{
    public class DbAccess : DbContext //nedarver fra DbContext fra entityframworket som er en del af netcore.all
    {
        public DbAccess(DbContextOptions<DbAccess> options):base(options) { }
        public DbSet<Biavler> Biavlers { get; set; } //model klasse
    }
}
