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
    [Migration("20180221175722_InitialMigration")]
    partial class InitialMigration
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentIdId");

                    b.HasKey("Id");

                    b.HasIndex("ParentIdId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Quiz.Models.Category", b =>
                {
                    b.HasOne("Quiz.Models.Category", "ParentId")
                        .WithMany("Children")
                        .HasForeignKey("ParentIdId");
                });
#pragma warning restore 612, 618
        }
    }
}