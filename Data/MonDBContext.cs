using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MonDBContext: DbContext
    {
        public MonDBContext(DbContextOptions<MonDBContext> options) : base(options) 
        { 
        }

        public DbSet<Formation> Formations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>()
                .Property(f => f.Descriotion)
                .HasMaxLength(500);
        }
    }
}
