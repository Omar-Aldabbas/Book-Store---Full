using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Store.Migrations
{
    /// <inheritdoc />
    public partial class FinishBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetailGenres_Genres_GenreId",
                table: "BookDetailGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetailGenres_Genres_GenreId",
                table: "BookDetailGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetailGenres_Genres_GenreId",
                table: "BookDetailGenres");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetailGenres_Genres_GenreId",
                table: "BookDetailGenres",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
