using Microsoft.EntityFrameworkCore.Migrations;

namespace belt2_exam.Migrations
{
    public partial class m12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hobbies_ProficiencyId",
                table: "Hobbies");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_ProficiencyId",
                table: "Hobbies",
                column: "ProficiencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Hobbies_ProficiencyId",
                table: "Hobbies");

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_ProficiencyId",
                table: "Hobbies",
                column: "ProficiencyId",
                unique: true);
        }
    }
}
