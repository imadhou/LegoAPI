using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LegoApi.Models;

namespace LegoApi.Data
{
    public class LegoApiContext: DbContext
    {
        public LegoApiContext(DbContextOptions<LegoApiContext> options)
            : base(options)
        {

        }
        public DbSet<Conge> Conges { get; set; }
        public DbSet<ContentManager> ContentManagers { get; set; }
        public DbSet<Developpeur> Developpeurs { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<EmployeConge> EmployeConges { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developpeur>().HasBaseType<Employe>();
            modelBuilder.Entity<ContentManager>().HasBaseType<Employe>();
            modelBuilder.Entity<Employe>().HasDiscriminator<string>("TypeEmploye")
                .HasValue<Developpeur>("Developpeur")
                .HasValue<ContentManager>("ContentManager");

            modelBuilder.Entity<EmployeConge>()
                .HasOne(e => e.Employe)
                .WithMany(ec => ec.EmployeConges)
                .HasForeignKey(eid => eid.EmployeId);

            modelBuilder.Entity<EmployeConge>()
                .HasOne(c => c.Conge)
                .WithMany(ec => ec.EmployeConges)
                .HasForeignKey(cid => cid.CongeID);

            modelBuilder.Entity<EmployeConge>()
                .Property(e => e.DateDebut)
                .HasDefaultValue(DateTime.Now);


        }
    }
}
