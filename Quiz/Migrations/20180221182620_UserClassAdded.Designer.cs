﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Quiz.Models;
using System;

namespace Quiz.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180221182620_UserClassAdded")]
    partial class UserClassAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quiz.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedById");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Quiz.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessLevel");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Quiz.Models.Category", b =>
                {
                    b.HasOne("Quiz.Models.User", "CreatedBy")
                        .WithMany("CreatedCategories")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Quiz.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}