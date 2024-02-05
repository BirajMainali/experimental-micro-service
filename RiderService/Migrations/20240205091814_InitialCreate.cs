using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiderService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "riderequests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    requestdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    requestedfordatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    confirmdatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_riderequests", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "riderequests");
        }
    }
}
