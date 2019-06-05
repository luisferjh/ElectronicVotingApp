using ElectronicVote.Data.Mapping;
using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CandidateMap());
            modelBuilder.ApplyConfiguration(new VoterUserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new VoteMap());
        }
    }
}
