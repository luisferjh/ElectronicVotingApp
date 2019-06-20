﻿// <auto-generated />
using System;
using ElectronicVote.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectronicVote.Data.Migrations
{
    [DbContext(typeof(DbContextElectronicVote))]
    partial class DbContextElectronicVoteModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectronicVote.Entities.Candidate", b =>
                {
                    b.Property<int>("IdCandidate")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("State");

                    b.HasKey("IdCandidate");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("ElectronicVote.Entities.ImageCandidate", b =>
                {
                    b.Property<int>("IdCandidate");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("IdCandidate");

                    b.ToTable("ImageCandidate");
                });

            modelBuilder.Entity("ElectronicVote.Entities.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Condition");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("IdRole");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("ElectronicVote.Entities.Vote", b =>
                {
                    b.Property<int>("IdUser");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("IdCandidate");

                    b.HasKey("IdUser");

                    b.HasIndex("IdCandidate");

                    b.ToTable("Vote");
                });

            modelBuilder.Entity("ElectronicVote.Entities.VoterUser", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("IdRole");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("Record")
                        .HasMaxLength(20);

                    b.Property<bool>("Voted");

                    b.HasKey("IdUser");

                    b.HasIndex("IdRole");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ElectronicVote.Entities.ImageCandidate", b =>
                {
                    b.HasOne("ElectronicVote.Entities.Candidate", "Candidate")
                        .WithOne("ImageCandidate")
                        .HasForeignKey("ElectronicVote.Entities.ImageCandidate", "IdCandidate")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ElectronicVote.Entities.Vote", b =>
                {
                    b.HasOne("ElectronicVote.Entities.Candidate", "Candidate")
                        .WithMany("Votes")
                        .HasForeignKey("IdCandidate")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ElectronicVote.Entities.VoterUser", "User")
                        .WithOne("Vote")
                        .HasForeignKey("ElectronicVote.Entities.Vote", "IdUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ElectronicVote.Entities.VoterUser", b =>
                {
                    b.HasOne("ElectronicVote.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
