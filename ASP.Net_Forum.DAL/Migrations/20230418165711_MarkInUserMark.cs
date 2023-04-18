using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.Net_Forum.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MarkInUserMark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "UserMarks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "UserMarks");
        }
    }
}
