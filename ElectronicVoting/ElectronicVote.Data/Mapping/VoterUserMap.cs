using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Data.Mapping
{
    public class VoterUserMap : IEntityTypeConfiguration<VoterUser>
    {
        public void Configure(EntityTypeBuilder<VoterUser> builder)
        {
            //Validations
            builder.Property(x => x.FullName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Record).HasMaxLength(20).IsRequired();
            builder.Property(x => x.Voted).IsRequired();           
            builder.Property(x => x.PasswordHash).HasMaxLength(64).IsRequired();
            builder.Property(x => x.PasswordSalt).HasMaxLength(64).IsRequired();

            //Relations
            builder.ToTable("User")
               .HasKey(p => p.IdUser);

            //Cascade Overrired on Role
            builder.HasOne(x => x.Role)
              .WithMany(x => x.Users)
              .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(x => x.Vote)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
