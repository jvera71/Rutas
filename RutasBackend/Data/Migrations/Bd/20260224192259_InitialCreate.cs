using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RutasBackend.Data.Migrations.Bd
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OfficialEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OfficialEntityUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficialEntityUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficialEntityUsers_OfficialEntities_OfficialEntityId",
                        column: x => x.OfficialEntityId,
                        principalTable: "OfficialEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfficialEntityUsers_OfficialEntityId",
                table: "OfficialEntityUsers",
                column: "OfficialEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficialEntityUsers");

            migrationBuilder.DropTable(
                name: "OfficialEntities");
        }
    }
}
