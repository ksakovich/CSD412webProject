using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class created_ListOfMovieLists_class_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_ListOfMovieLists_ListOfMovieListsId",
                table: "MovieList");

            migrationBuilder.AlterColumn<int>(
                name: "ListOfMovieListsId",
                table: "MovieList",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_ListOfMovieLists_ListOfMovieListsId",
                table: "MovieList",
                column: "ListOfMovieListsId",
                principalTable: "ListOfMovieLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieList_ListOfMovieLists_ListOfMovieListsId",
                table: "MovieList");

            migrationBuilder.AlterColumn<int>(
                name: "ListOfMovieListsId",
                table: "MovieList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MovieList_ListOfMovieLists_ListOfMovieListsId",
                table: "MovieList",
                column: "ListOfMovieListsId",
                principalTable: "ListOfMovieLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
