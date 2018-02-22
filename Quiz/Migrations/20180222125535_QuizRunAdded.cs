using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Quiz.Migrations
{
    public partial class QuizRunAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Questions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "QuizRuns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParticipantId = table.Column<int>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizRuns_Users_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizRuns_ParticipantId",
                table: "QuizRuns",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuizRuns");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Questions");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
