using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RutasBackend.Data.Migrations.Bd
{
    /// <inheritdoc />
    public partial class FinalSchemaFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "OfficialEntityUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_OfficialEntityUsers_ApplicationUserId",
                table: "OfficialEntityUsers",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenUsers_OfficialEntityId",
                table: "CitizenUsers",
                column: "OfficialEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenUsers_OfficialEntities_OfficialEntityId",
                table: "CitizenUsers",
                column: "OfficialEntityId",
                principalTable: "OfficialEntities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenUsers_OfficialEntities_OfficialEntityId",
                table: "CitizenUsers");

            migrationBuilder.DropIndex(
                name: "IX_OfficialEntityUsers_ApplicationUserId",
                table: "OfficialEntityUsers");

            migrationBuilder.DropIndex(
                name: "IX_CitizenUsers_OfficialEntityId",
                table: "CitizenUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "OfficialEntityUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
