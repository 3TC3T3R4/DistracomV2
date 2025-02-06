using Domain.Distracom.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Distracom.Data
{
    public class DistracomDbContext : DbContext
    {
        public DistracomDbContext(DbContextOptions<DistracomDbContext> options)
           : base(options)
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Station> Stations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación entre Company y Station (1:N)
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Stations)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyId);

            // Puedes añadir más configuraciones, como validaciones o configuraciones de tablas

            base.OnModelCreating(modelBuilder);
        }

    }
}
