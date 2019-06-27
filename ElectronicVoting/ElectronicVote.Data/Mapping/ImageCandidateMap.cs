using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Data.Mapping
{
    public class ImageCandidateMap : IEntityTypeConfiguration<ImageCandidate>
    {
        public void Configure(EntityTypeBuilder<ImageCandidate> builder)
        {
            builder.Property(x => x.ImagePath).HasMaxLength(400).IsRequired();          

            builder.ToTable("ImageCandidate")
              .HasKey(p => p.IdCandidate);

            //relations
            builder.HasOne(x => x.Candidate)
                .WithOne(x => x.ImageCandidate)
                .HasForeignKey<ImageCandidate>(fk => fk.IdCandidate);
            
        }
    }
}
