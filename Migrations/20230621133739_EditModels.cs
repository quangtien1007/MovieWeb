using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Migrations
{
    /// <inheritdoc />
    public partial class EditModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCompany_Company_CompanyID",
                table: "MovieCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCompany_Movie_MovieId",
                table: "MovieCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenre_MovieId",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieCompany_MovieId",
                table: "MovieCompany");

            migrationBuilder.RenameColumn(
                name: "CompanyID",
                table: "MovieCompany",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCompany_CompanyID",
                table: "MovieCompany",
                newName: "IX_MovieCompany_CompanyId");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieGenre",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "MovieGenre",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "MovieGenre",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieCompany",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "MovieCompany",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesId",
                table: "MovieCompany",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MoviesId",
                table: "MovieGenre",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompany_MoviesId",
                table: "MovieCompany",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCompany_Company_CompanyId",
                table: "MovieCompany",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCompany_Movie_MoviesId",
                table: "MovieCompany",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_MoviesId",
                table: "MovieGenre",
                column: "MoviesId",
                principalTable: "Movie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCompany_Company_CompanyId",
                table: "MovieCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCompany_Movie_MoviesId",
                table: "MovieCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenre_Movie_MoviesId",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenre_MoviesId",
                table: "MovieGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieCompany_MoviesId",
                table: "MovieCompany");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "MovieGenre");

            migrationBuilder.DropColumn(
                name: "MoviesId",
                table: "MovieCompany");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "MovieCompany",
                newName: "CompanyID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCompany_CompanyId",
                table: "MovieCompany",
                newName: "IX_MovieCompany_CompanyID");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieGenre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "MovieGenre",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieCompany",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyID",
                table: "MovieCompany",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieId",
                table: "MovieGenre",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompany_MovieId",
                table: "MovieCompany",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCompany_Company_CompanyID",
                table: "MovieCompany",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCompany_Movie_MovieId",
                table: "MovieCompany",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Genre_GenreId",
                table: "MovieGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenre_Movie_MovieId",
                table: "MovieGenre",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
