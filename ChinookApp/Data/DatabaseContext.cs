using ChinookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChinookApp.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<Track> Tracks { get; set; }


    }
}
