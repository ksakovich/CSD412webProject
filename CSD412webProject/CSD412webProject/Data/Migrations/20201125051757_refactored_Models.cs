using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class refactored_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_AspNetUsers_UserId1",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_MovieList_UserId1",
                table: "MovieList");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MovieList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MovieList",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieListId",
                table: "Movie",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FavoritesMovieListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchLaterMovieListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_MovieListId",
                table: "Movie",
                column: "MovieListId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieList_MovieListId",
                table: "Movie",
                column: "MovieListId",
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
                name: "FK_AspNetUsers_MovieList_FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MovieList_WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieList_MovieListId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_AspNetUsers_UserId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_MovieList_UserId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_Movie_MovieListId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MovieList",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MovieList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieListId",
                table: "Movie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieList_UserId1",
                table: "MovieList",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_AspNetUsers_UserId1",
                table: "MovieList",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
