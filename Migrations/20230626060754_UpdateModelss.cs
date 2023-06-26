using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "MovieCast");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Cast",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostCast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCast_Cast_CastId",
                        column: x => x.CastId,
                        principalTable: "Cast",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCast_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostGenres_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostGenres_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCast_CastId",
                table: "PostCast",
                column: "CastId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCast_PostId",
                table: "PostCast",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGenres_GenreId",
                table: "PostGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGenres_PostId",
                table: "PostGenres",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostCast");

            migrationBuilder.DropTable(
                name: "PostGenres");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Cast");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "MovieCast",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
