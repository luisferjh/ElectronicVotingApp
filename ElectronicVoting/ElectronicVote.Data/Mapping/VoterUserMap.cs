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
            builder.Property(x => x.FullName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.Record).IsRequired();
            builder.Property(x => x.Voted).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(40).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(250).IsRequired();
            builder.Property(x => x.PasswordSalt).HasMaxLength(250).IsRequired();

            //Relations
            builder.ToTable("User")
               .HasKey(p => p.IdUser);

            //Cascade Overrired on Role
            builder.HasOne(x => x.Role)
              .WithMany(x => x.Users)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
