using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesApi.Migrations
{
    /// <inheritdoc />
    public partial class HeroPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroPicture",
                table: "Heroes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeroPicture",
                table: "Heroes");
        }
    }
}
