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
        public DbSet<Avis> Avis { get; set; }
        public DbSet<ContactMessage> Messages { get; set; }

        //get data
        FormationMemoryRepository repository = new FormationMemoryRepository();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Formation>()
                .Property(f => f.Descriotion)
                .HasMaxLength(500);

            modelBuilder.Entity<Formation>().HasData(repository.GetAllFormations());
        }
    }
}
