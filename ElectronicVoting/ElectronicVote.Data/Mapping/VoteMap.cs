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
            //Relations
            builder.ToTable("Vote")              
               .HasKey(p => new { p.IdUser, p.IdCandidate });
        }
    }
}
