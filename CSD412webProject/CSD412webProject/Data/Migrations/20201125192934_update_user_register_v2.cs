using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class update_user_register_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MovieList",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieListFK1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieListFK2",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MovieListFK1",
                table: "AspNetUsers",
                column: "MovieListFK1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MovieListFK2",
                table: "AspNetUsers",
                column: "MovieListFK2");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MovieList_MovieListFK1",
                table: "AspNetUsers",
                column: "MovieListFK1",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MovieList_MovieListFK2",
                table: "AspNetUsers",
                column: "MovieListFK2",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_AspNetUsers_UserId",
                table: "MovieList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MovieList_MovieListFK1",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MovieList_MovieListFK2",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_AspNetUsers_UserId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MovieListFK1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MovieListFK2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MovieListFK1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MovieListFK2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MovieList",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
