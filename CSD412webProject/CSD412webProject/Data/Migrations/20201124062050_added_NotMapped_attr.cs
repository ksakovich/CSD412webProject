using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class added_NotMapped_attr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MovieList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Movie",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MovieList");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Movie");
        }
    }
}
