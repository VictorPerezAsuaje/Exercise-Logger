using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseLog.Infrastructure.Data.Migrations
{
    public partial class AddedBaseExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DistanceExercises");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CalisthenicExercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "DistanceExercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "CalisthenicExercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistanceExercises_ExerciseId",
                table: "DistanceExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_CalisthenicExercises_ExerciseId",
                table: "CalisthenicExercises",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalisthenicExercises_Exercises_ExerciseId",
                table: "CalisthenicExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DistanceExercises_Exercises_ExerciseId",
                table: "DistanceExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalisthenicExercises_Exercises_ExerciseId",
                table: "CalisthenicExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_DistanceExercises_Exercises_ExerciseId",
                table: "DistanceExercises");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_DistanceExercises_ExerciseId",
                table: "DistanceExercises");

            migrationBuilder.DropIndex(
                name: "IX_CalisthenicExercises_ExerciseId",
                table: "CalisthenicExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "DistanceExercises");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "CalisthenicExercises");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DistanceExercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CalisthenicExercises",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
