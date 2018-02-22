using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Quiz.Migrations
{
    public partial class QuestionResponseClassAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionId = table.Column<int>(nullable: false),
                    QuizRunId = table.Column<int>(nullable: false),
                    ResponseOrder = table.Column<int>(nullable: false),
                    SelectedAnswerId = table.Column<int>(nullable: false),
                    TimePassed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_QuizRuns_QuizRunId",
                        column: x => x.QuizRunId,
                        principalTable: "QuizRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionResponse_Answers_SelectedAnswerId",
                        column: x => x.SelectedAnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_QuestionId",
                table: "QuestionResponse",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_QuizRunId",
                table: "QuestionResponse",
                column: "QuizRunId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResponse_SelectedAnswerId",
                table: "QuestionResponse",
                column: "SelectedAnswerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionResponse");
        }
    }
}
