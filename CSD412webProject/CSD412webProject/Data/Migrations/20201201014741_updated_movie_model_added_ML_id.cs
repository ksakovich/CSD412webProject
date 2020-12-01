using Microsoft.EntityFrameworkCore.Migrations;

namespace CSD412webProject.Data.Migrations
{
    public partial class updated_movie_model_added_ML_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieList_MovieListId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieListId",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieList_MovieListId",
                table: "Movie",
                column: "MovieListId",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieList_MovieListId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieListId",
                table: "Movie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieList_MovieListId",
                table: "Movie",
                column: "MovieListId",
                principalTable: "MovieList",
                principalColumn: "MovieListId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
