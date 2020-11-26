using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class created_ListOfMovieLists_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UserId",
                table: "MovieList");

            migrationBuilder.DropColumn(
                name: "MovieListFK1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MovieListFK2",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ListOfMovieListsId",
                table: "MovieList",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoritesMovieListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WatchLaterMovieListId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListOfMovieLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfMovieLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListOfMovieLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieList_ListOfMovieListsId",
                table: "MovieList",
                column: "ListOfMovieListsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FavoritesMovieListId",
                table: "AspNetUsers",
                column: "FavoritesMovieListId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WatchLaterMovieListId",
                table: "AspNetUsers",
                column: "WatchLaterMovieListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfMovieLists_UserId",
                table: "ListOfMovieLists",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "FK_MovieList_ListOfMovieLists_ListOfMovieListsId",
                table: "MovieList",
                column: "ListOfMovieListsId",
                principalTable: "ListOfMovieLists",
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
                name: "FK_MovieList_ListOfMovieLists_ListOfMovieListsId",
                table: "MovieList");

            migrationBuilder.DropTable(
                name: "ListOfMovieLists");

            migrationBuilder.DropIndex(
                name: "IX_MovieList_ListOfMovieListsId",
                table: "MovieList");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ListOfMovieListsId",
                table: "MovieList");

            migrationBuilder.DropColumn(
                name: "FavoritesMovieListId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WatchLaterMovieListId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MovieList",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieListFK1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieListFK2",
                table: "AspNetUsers",
                type: "int",
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
    }
}
