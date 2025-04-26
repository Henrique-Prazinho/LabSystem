using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
