using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesApi.Migrations
{
    /// <inheritdoc />
    public partial class cascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroItemPowers_Heroes_HeroId",
                table: "HeroItemPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroItemPowers_Powers_PowerId",
                table: "HeroItemPowers");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroItemPowers_Heroes_HeroId",
                table: "HeroItemPowers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroItemPowers_Powers_PowerId",
                table: "HeroItemPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeroItemPowers_Heroes_HeroId",
                table: "HeroItemPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroItemPowers_Powers_PowerId",
                table: "HeroItemPowers");

            migrationBuilder.AddForeignKey(
                name: "FK_HeroItemPowers_Heroes_HeroId",
                table: "HeroItemPowers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroItemPowers_Powers_PowerId",
                table: "HeroItemPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
