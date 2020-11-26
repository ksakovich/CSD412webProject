using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class added_InverseProperty_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ListOfMovieLists_UserId",
                table: "ListOfMovieLists");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMovieLists_UserId",
                table: "ListOfMovieLists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ListOfMovieLists_UserId",
                table: "ListOfMovieLists");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMovieLists_UserId",
                table: "ListOfMovieLists",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}
