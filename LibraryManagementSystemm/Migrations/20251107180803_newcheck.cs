using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementSystemm.Migrations
{
    /// <inheritdoc />
    public partial class newcheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Librarys",
                newName: "Location");

            migrationBuilder.AddColumn<DateTime>(
                name: "MembershipDate",
                table: "Members",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipDate",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Librarys",
                newName: "Address");
        }
    }
}
