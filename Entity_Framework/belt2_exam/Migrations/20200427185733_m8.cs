using Microsoft.EntityFrameworkCore.Migrations;

namespace belt2_exam.Migrations
{
    public partial class m8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proficiencies_Hobbies_HobbyId",
                table: "Proficiencies");

            migrationBuilder.DropIndex(
                name: "IX_Proficiencies_HobbyId",
                table: "Proficiencies");

            migrationBuilder.DropColumn(
                name: "HobbyId",
                table: "Proficiencies");

            migrationBuilder.AddColumn<int>(
                name: "ProficiencyId",
                table: "Hobbies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_ProficiencyId",
                table: "Hobbies",
                column: "ProficiencyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbies_Proficiencies_ProficiencyId",
                table: "Hobbies",
                column: "ProficiencyId",
                principalTable: "Proficiencies",
                principalColumn: "ProficiencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbies_Proficiencies_ProficiencyId",
                table: "Hobbies");

            migrationBuilder.DropIndex(
                name: "IX_Hobbies_ProficiencyId",
                table: "Hobbies");

            migrationBuilder.DropColumn(
                name: "ProficiencyId",
                table: "Hobbies");

            migrationBuilder.AddColumn<int>(
                name: "HobbyId",
                table: "Proficiencies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_HobbyId",
                table: "Proficiencies",
                column: "HobbyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proficiencies_Hobbies_HobbyId",
                table: "Proficiencies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "HobbyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
