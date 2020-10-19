using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leavemanagementsystem.Data.Migrations
{
    public partial class LeaveTypeDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LeaveTypes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DetailsLeaveTypeViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsLeaveTypeViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailsLeaveTypeViewModel");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LeaveTypes");
        }
    }
}
