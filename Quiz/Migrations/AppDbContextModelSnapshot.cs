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
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quiz.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCorrect");

                    b.Property<int?>("QuestionId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Quiz.Models.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ColumnName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("KeyValue");

                    b.Property<string>("NewValue")
                        .IsRequired();

                    b.Property<string>("OldValue")
                        .IsRequired();

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("Quiz.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Quiz.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("CreatedById");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Difficulty");

                    b.Property<bool>("IsActive");

                    b.Property<int>("MaxSecondsToComplete");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedById");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Quiz.Models.QuestionResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.Property<int>("QuizRunId");

                    b.Property<int>("ResponseOrder");

                    b.Property<int>("SelectedAnswerId");

                    b.Property<int>("TimePassed");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuizRunId");

                    b.HasIndex("SelectedAnswerId");

                    b.ToTable("QuestionResponse");
                });

            modelBuilder.Entity("Quiz.Models.QuizRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ParticipantId");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.ToTable("QuizRuns");
                });

            modelBuilder.Entity("Quiz.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessLevel");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Quiz.Models.Answer", b =>
                {
                    b.HasOne("Quiz.Models.User", "CreatedBy")
                        .WithMany("CreatedAnswers")
                        .HasForeignKey("CreatedById");

                    b.HasOne("Quiz.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Quiz.Models.Category", b =>
                {
                    b.HasOne("Quiz.Models.User", "CreatedBy")
                        .WithMany("CreatedCategories")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Quiz.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Quiz.Models.Question", b =>
                {
                    b.HasOne("Quiz.Models.Category", "Category")
                        .WithMany("Questions")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Quiz.Models.User", "CreatedBy")
                        .WithMany("CreatedQuestions")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Quiz.Models.QuestionResponse", b =>
                {
                    b.HasOne("Quiz.Models.Question", "Question")
                        .WithMany("QuestionResponses")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Quiz.Models.QuizRun", "QuizRun")
                        .WithMany("QuestionResponses")
                        .HasForeignKey("QuizRunId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Quiz.Models.Answer", "SelectedAnswer")
                        .WithMany("QuestionResponses")
                        .HasForeignKey("SelectedAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Quiz.Models.QuizRun", b =>
                {
                    b.HasOne("Quiz.Models.User", "Participant")
                        .WithMany("QuizRuns")
                        .HasForeignKey("ParticipantId");
                });
#pragma warning restore 612, 618
        }
    }
}
