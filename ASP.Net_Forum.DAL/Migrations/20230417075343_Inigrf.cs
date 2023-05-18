using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASP.Net_Forum.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Inigrf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteCatigories");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Categories",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Дизайн" },
                    { 2, "Мобильная разработка" },
                    { 3, "Web" },
                    { 4, "Desktop" },
                    { 5, "Big Date" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Categories_CategoryId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_CategoryId",
                table: "Notes");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "NoteCatigories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Categoriesid = table.Column<int>(type: "int", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    CatigoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteCatigories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteCatigories_Categories_Categoriesid",
                        column: x => x.Categoriesid,
                        principalTable: "Categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteCatigories_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCatigories_Categoriesid",
                table: "NoteCatigories",
                column: "Categoriesid");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCatigories_NoteId",
                table: "NoteCatigories",
                column: "NoteId");
        }
    }
}
