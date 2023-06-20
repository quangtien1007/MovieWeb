using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Migrations
{
    /// <inheritdoc />
    public partial class EditMovieCastModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Movie_MovieId",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCast");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieCast",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "MovieCast",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MoviesId",
                table: "MovieCast",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Movie_MoviesId",
                table: "MovieCast",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Movie_MoviesId",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_MoviesId",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "MovieCast");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieCast",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_MovieId",
                table: "MovieCast",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Movie_MovieId",
                table: "MovieCast",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
