using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Migrations
{
    /// <inheritdoc />
    public partial class AdjustModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Gender_GenderId",
                table: "MovieCast");

            migrationBuilder.DropIndex(
                name: "IX_MovieCast_GenderId",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "MovieCast");

            migrationBuilder.AlterColumn<string>(
                name: "CastName",
                table: "MovieCast",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CastImage",
                table: "MovieCast",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "MovieCast",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Movie_Status",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Movie",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CastImage",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MovieCast");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Movie");

            migrationBuilder.AlterColumn<string>(
                name: "CastName",
                table: "MovieCast",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "MovieCast",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Movie_Status",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieCast_GenderId",
                table: "MovieCast",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Gender_GenderId",
                table: "MovieCast",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id");
        }
    }
}
