using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RutasBackend.Data.Migrations.Bd
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenUsers_OfficialEntities_OfficialEntityId",
                table: "CitizenUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfficialEntityId",
                table: "CitizenUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenUsers_OfficialEntities_OfficialEntityId",
                table: "CitizenUsers",
                column: "OfficialEntityId",
                principalTable: "OfficialEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CitizenUsers_OfficialEntities_OfficialEntityId",
                table: "CitizenUsers");

            migrationBuilder.AlterColumn<Guid>(
                name: "OfficialEntityId",
                table: "CitizenUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_CitizenUsers_OfficialEntities_OfficialEntityId",
                table: "CitizenUsers",
                column: "OfficialEntityId",
                principalTable: "OfficialEntities",
                principalColumn: "Id");
        }
    }
}
