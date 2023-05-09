using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Net_Forum.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DeleteRaiting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raiting",
                table: "Notes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Raiting",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
