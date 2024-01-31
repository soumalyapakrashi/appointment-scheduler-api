using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appointment_scheduler_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMeetingsDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Meetings",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Meetings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Meetings");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Meetings",
                newName: "Date");
        }
    }
}
