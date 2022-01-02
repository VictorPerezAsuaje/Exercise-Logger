using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseLog.Infrastructure.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalisthenicExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraWeight = table.Column<bool>(type: "bit", nullable: false),
                    AddedWeight = table.Column<int>(type: "int", nullable: false),
                    ExerciseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    MeasuredBy = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalisthenicExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalisthenicExercises_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistanceExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraWeight = table.Column<bool>(type: "bit", nullable: false),
                    AddedWeight = table.Column<int>(type: "int", nullable: false),
                    ExerciseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: false),
                    Meters = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistanceExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistanceExercises_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalisthenicExercises_TraineeId",
                table: "CalisthenicExercises",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_DistanceExercises_TraineeId",
                table: "DistanceExercises",
                column: "TraineeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalisthenicExercises");

            migrationBuilder.DropTable(
                name: "DistanceExercises");

            migrationBuilder.DropTable(
                name: "Trainees");
        }
    }
}
