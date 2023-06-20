using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Migrations
{
    /// <inheritdoc />
    public partial class EditCastModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Person_PersonId",
                table: "MovieCast");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropColumn(
                name: "CastImage",
                table: "MovieCast");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "MovieCast",
                newName: "CastId");

            migrationBuilder.RenameColumn(
                name: "CastName",
                table: "MovieCast",
                newName: "CharacterName");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_PersonId",
                table: "MovieCast",
                newName: "IX_MovieCast_CastId");

            migrationBuilder.AlterColumn<string>(
                name: "Movie_Status",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Cast_CastId",
                table: "MovieCast",
                column: "CastId",
                principalTable: "Cast",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCast_Cast_CastId",
                table: "MovieCast");

            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.RenameColumn(
                name: "CharacterName",
                table: "MovieCast",
                newName: "CastName");

            migrationBuilder.RenameColumn(
                name: "CastId",
                table: "MovieCast",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCast_CastId",
                table: "MovieCast",
                newName: "IX_MovieCast_PersonId");

            migrationBuilder.AddColumn<string>(
                name: "CastImage",
                table: "MovieCast",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Movie_Status",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCast_Person_PersonId",
                table: "MovieCast",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
