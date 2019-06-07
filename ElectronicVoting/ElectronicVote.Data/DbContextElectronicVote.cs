using ElectronicVote.Data.Mapping;
using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicVote.Data
{
    public class DbContextElectronicVote : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<VoterUser> VoterUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Vote> Votes { get; set; }

        public DbContextElectronicVote(DbContextOptions<DbContextElectronicVote> options)
             : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn");
                }
            }
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CandidateMap());
            modelBuilder.ApplyConfiguration(new VoterUserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new VoteMap());
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Added))
            {
                if (entry.Entity.GetType().GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("CreatedOn").CurrentValue = timestamp;
                    }
                }
            }
            return base.SaveChanges();            
        }
    }
}
