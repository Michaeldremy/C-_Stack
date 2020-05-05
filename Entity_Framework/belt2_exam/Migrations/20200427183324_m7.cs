using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace belt2_exam.Migrations
{
    public partial class m7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProficiencyId",
                table: "Associations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Proficiencies",
                columns: table => new
                {
                    ProficiencyId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProficiencyLevel = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    HobbyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proficiencies", x => x.ProficiencyId);
                    table.ForeignKey(
                        name: "FK_Proficiencies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "HobbyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proficiencies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Associations_ProficiencyId",
                table: "Associations",
                column: "ProficiencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_HobbyId",
                table: "Proficiencies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Proficiencies_UserId",
                table: "Proficiencies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Associations_Proficiencies_ProficiencyId",
                table: "Associations",
                column: "ProficiencyId",
                principalTable: "Proficiencies",
                principalColumn: "ProficiencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Associations_Proficiencies_ProficiencyId",
                table: "Associations");

            migrationBuilder.DropTable(
                name: "Proficiencies");

            migrationBuilder.DropIndex(
                name: "IX_Associations_ProficiencyId",
                table: "Associations");

            migrationBuilder.DropColumn(
                name: "ProficiencyId",
                table: "Associations");
        }
    }
}
