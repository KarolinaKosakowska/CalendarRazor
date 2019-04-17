using Microsoft.EntityFrameworkCore.Migrations;

namespace CalendarRazor.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarTypeId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CalendarTypeId",
                table: "Tasks",
                column: "CalendarTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Types_CalendarTypeId",
                table: "Tasks",
                column: "CalendarTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Types_CalendarTypeId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CalendarTypeId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CalendarTypeId",
                table: "Tasks");
        }
    }
}
