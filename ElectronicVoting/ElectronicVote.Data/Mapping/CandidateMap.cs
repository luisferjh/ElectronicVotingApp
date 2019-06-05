using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Data.Mapping
{
    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.State).IsRequired();

            builder.ToTable("Candidate")
              .HasKey(p => p.IdCandidate);

            //relations
            builder.HasOne(x => x.Vote)
                .WithMany(x => x.Candidates)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
