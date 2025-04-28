using Microsoft.EntityFrameworkCore;
using SistemaLab.Models;

namespace SistemaLab.Data
{
    public class SistemaLabContext : DbContext
    {
        public SistemaLabContext (DbContextOptions<SistemaLabContext> options)
            : base(options)
        {
        }

        public DbSet<SistemaLab.Models.User> User{ get; set; } = default!;
        public DbSet<SistemaLab.Models.Product> Products { get; set; } = default!;
    }
}
