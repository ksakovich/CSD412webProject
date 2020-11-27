using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class new_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MovieList_FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MovieList_WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WatchLaterMovieListId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoritesMovieListId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchLaterMovieListId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoritesMovieListId",
                table: "AspNetUsers",
                column: "FavoritesMovieListId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WatchLaterMovieListId",
                table: "AspNetUsers",
                column: "WatchLaterMovieListId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MovieList_FavoritesMovieListId",
                table: "AspNetUsers",
                column: "FavoritesMovieListId",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MovieList_WatchLaterMovieListId",
                table: "AspNetUsers",
                column: "WatchLaterMovieListId",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
