using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministrativeService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bookinghistories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    requestdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    customer = table.Column<string>(type: "text", nullable: false),
                    requestedfordatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    rider = table.Column<string>(type: "text", nullable: true),
                    confirmdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    isconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    iscancelled = table.Column<bool>(type: "boolean", nullable: false),
                    canceldatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    cancelreason = table.Column<string>(type: "text", nullable: true),
                    cancelledby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bookinghistories", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookinghistories");
        }
    }
}
