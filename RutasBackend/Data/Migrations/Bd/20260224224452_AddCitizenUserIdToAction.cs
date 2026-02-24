using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RutasBackend.Data.Migrations.Bd
{
    /// <inheritdoc />
    public partial class AddCitizenUserIdToAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CitizenUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    LocalUserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CamouflageMode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HardwareAlertsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    OfficialEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportPins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    IssueType = table.Column<int>(type: "int", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafeHavens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Is24Hours = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafeHavens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizenUserActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialEntityUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CitizenUserActionType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenUserActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CitizenUserActions_CitizenUsers_CitizenUserId",
                        column: x => x.CitizenUserId,
                        principalTable: "CitizenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CitizenUserActions_OfficialEntityUsers_OfficialEntityUserId",
                        column: x => x.OfficialEntityUserId,
                        principalTable: "OfficialEntityUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartLatitude = table.Column<double>(type: "float", nullable: false),
                    StartLongitude = table.Column<double>(type: "float", nullable: false),
                    DestinationLatitude = table.Column<double>(type: "float", nullable: false),
                    DestinationLongitude = table.Column<double>(type: "float", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UsedSafeRoute = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journeys_CitizenUsers_CitizenUserId",
                        column: x => x.CitizenUserId,
                        principalTable: "CitizenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PanicAlerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CitizenUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    TriggeredAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TriggerMethod = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EncryptedMediaLocation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanicAlerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PanicAlerts_CitizenUsers_CitizenUserId",
                        column: x => x.CitizenUserId,
                        principalTable: "CitizenUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanionSegments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JourneyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanionUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartLatitude = table.Column<double>(type: "float", nullable: true),
                    StartLongitude = table.Column<double>(type: "float", nullable: true),
                    EndLatitude = table.Column<double>(type: "float", nullable: true),
                    EndLongitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanionSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanionSegments_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CitizenUserActions_CitizenUserId",
                table: "CitizenUserActions",
                column: "CitizenUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenUserActions_OfficialEntityUserId",
                table: "CitizenUserActions",
                column: "OfficialEntityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CitizenUsers_Code",
                table: "CitizenUsers",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompanionSegments_JourneyId",
                table: "CompanionSegments",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_Journeys_CitizenUserId",
                table: "Journeys",
                column: "CitizenUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PanicAlerts_CitizenUserId",
                table: "PanicAlerts",
                column: "CitizenUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CitizenUserActions");

            migrationBuilder.DropTable(
                name: "CompanionSegments");

            migrationBuilder.DropTable(
                name: "PanicAlerts");

            migrationBuilder.DropTable(
                name: "ReportPins");

            migrationBuilder.DropTable(
                name: "SafeHavens");

            migrationBuilder.DropTable(
                name: "Journeys");

            migrationBuilder.DropTable(
                name: "CitizenUsers");
        }
    }
}
