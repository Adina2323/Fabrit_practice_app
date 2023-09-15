using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeroesApi.Migrations
{
    /// <inheritdoc />
    public partial class FinalTouches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "HeroPicture",
                table: "Heroes");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Users",
                newName: "ProfilePictureId");

            migrationBuilder.AddColumn<long>(
                name: "HeroId",
                table: "Images",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Images",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Heroes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Heroes",
                type: "nvarchar(max)",
                maxLength: 500000000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PowerType = table.Column<int>(type: "int", nullable: false),
                    PowerTypeAsString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroItemPowers",
                columns: table => new
                {
                    HeroId = table.Column<long>(type: "bigint", nullable: false),
                    PowerId = table.Column<long>(type: "bigint", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroItemPowers", x => new { x.HeroId, x.PowerId });
                    table.ForeignKey(
                        name: "FK_HeroItemPowers_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroItemPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_HeroId",
                table: "Users",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HeroId",
                table: "Images",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroItemPowers_PowerId",
                table: "HeroItemPowers",
                column: "PowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Heroes_HeroId",
                table: "Images",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Heroes_HeroId",
                table: "Users",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Images_ProfilePictureId",
                table: "Users",
                column: "ProfilePictureId",
                principalTable: "Images",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Heroes_HeroId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Heroes_HeroId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Images_ProfilePictureId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "HeroItemPowers");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_Users_HeroId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_ProfilePictureId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Images_HeroId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "ProfilePictureId",
                table: "Users",
                newName: "ImageId");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Heroes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Heroes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 500000000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeroPicture",
                table: "Heroes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
