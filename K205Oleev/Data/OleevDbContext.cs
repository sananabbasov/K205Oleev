using K205Oleev.Models;
using Microsoft.EntityFrameworkCore;

namespace K205Oleev.Data
{
    public class OleevDbContext : DbContext
    {
        public OleevDbContext(DbContextOptions<OleevDbContext> options)
            : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Info> Infos { get; set; }
    }
}
