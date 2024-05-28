﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Quiz.Context;

#nullable disable

namespace Quiz.Migrations
{
    [DbContext(typeof(QuizContext))]
    [Migration("20231107133124_OneMigration")]
    partial class OneMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Quiz.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnswerId"));

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Iscorrect")
                        .HasColumnType("boolean");

                    b.Property<int>("questionId")
                        .HasColumnType("integer");

                    b.HasKey("AnswerId");

                    b.HasIndex("questionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            AnswerText = "2",
                            Iscorrect = true,
                            questionId = 1
                        },
                        new
                        {
                            AnswerId = 2,
                            AnswerText = "4",
                            Iscorrect = false,
                            questionId = 1
                        },
                        new
                        {
                            AnswerId = 3,
                            AnswerText = "0",
                            Iscorrect = false,
                            questionId = 1
                        },
                        new
                        {
                            AnswerId = 4,
                            AnswerText = "10",
                            Iscorrect = false,
                            questionId = 1
                        },
                        new
                        {
                            AnswerId = 5,
                            AnswerText = "2",
                            Iscorrect = false,
                            questionId = 2
                        },
                        new
                        {
                            AnswerId = 6,
                            AnswerText = "4",
                            Iscorrect = false,
                            questionId = 2
                        },
                        new
                        {
                            AnswerId = 7,
                            AnswerText = "0",
                            Iscorrect = true,
                            questionId = 2
                        },
                        new
                        {
                            AnswerId = 8,
                            AnswerText = "10",
                            Iscorrect = false,
                            questionId = 2
                        },
                        new
                        {
                            AnswerId = 9,
                            AnswerText = "20",
                            Iscorrect = false,
                            questionId = 3
                        },
                        new
                        {
                            AnswerId = 10,
                            AnswerText = "5",
                            Iscorrect = true,
                            questionId = 3
                        },
                        new
                        {
                            AnswerId = 11,
                            AnswerText = "30",
                            Iscorrect = false,
                            questionId = 3
                        },
                        new
                        {
                            AnswerId = 12,
                            AnswerText = "10",
                            Iscorrect = false,
                            questionId = 3
                        },
                        new
                        {
                            AnswerId = 13,
                            AnswerText = "Red",
                            Iscorrect = false,
                            questionId = 4
                        },
                        new
                        {
                            AnswerId = 14,
                            AnswerText = "Green",
                            Iscorrect = true,
                            questionId = 4
                        },
                        new
                        {
                            AnswerId = 15,
                            AnswerText = "Blue",
                            Iscorrect = false,
                            questionId = 4
                        },
                        new
                        {
                            AnswerId = 16,
                            AnswerText = "Black",
                            Iscorrect = false,
                            questionId = 4
                        },
                        new
                        {
                            AnswerId = 17,
                            AnswerText = "Gray",
                            Iscorrect = false,
                            questionId = 4
                        });
                });

            modelBuilder.Entity("Quiz.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionId"));

                    b.Property<int>("AnswerGivenIndex")
                        .HasColumnType("integer");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("QuestionId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            QuestionId = 1,
                            AnswerGivenIndex = 0,
                            QuestionText = "What is the result of 1+1?"
                        },
                        new
                        {
                            QuestionId = 2,
                            AnswerGivenIndex = 0,
                            QuestionText = "What is the result of 1-1?"
                        },
                        new
                        {
                            QuestionId = 3,
                            AnswerGivenIndex = 0,
                            QuestionText = "What is the result of 10-5?"
                        },
                        new
                        {
                            QuestionId = 4,
                            AnswerGivenIndex = 0,
                            QuestionText = "What color ir grass?"
                        });
                });

            modelBuilder.Entity("Quiz.Models.Answer", b =>
                {
                    b.HasOne("Quiz.Models.Question", "question")
                        .WithMany("Answers")
                        .HasForeignKey("questionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("question");
                });

            modelBuilder.Entity("Quiz.Models.Question", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
