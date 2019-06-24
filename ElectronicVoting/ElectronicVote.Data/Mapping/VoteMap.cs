using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Data.Mapping
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Vote")
              .HasKey(p => p.IdUser);

            //builder.ToTable("Vote")              
            //   .HasKey(p => new { p.IdUser, p.IdCandidate });

            //Relations            
            // relation with Sale entity 1 to 1
            builder.HasOne(p => p.User)
                .WithOne(i => i.Vote)
                .HasForeignKey<Vote>(d => d.IdUser)      
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Candidate)
              .WithMany(x => x.Votes)            
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
