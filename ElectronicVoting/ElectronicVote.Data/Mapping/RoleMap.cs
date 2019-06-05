using ElectronicVote.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Data.Mapping
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Validations
            builder.Property(x => x.RoleName).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Condition).IsRequired();

            //Relations
            builder.ToTable("Role")
               .HasKey(p => p.IdRole);
        }
    }
}
