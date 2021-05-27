using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BTUserProject_Project_PorjectsId",
                table: "BTUserProject");

            migrationBuilder.RenameColumn(
                name: "PorjectsId",
                table: "BTUserProject",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_BTUserProject_PorjectsId",
                table: "BTUserProject",
                newName: "IX_BTUserProject_ProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BTUserProject_Project_ProjectsId",
                table: "BTUserProject",
                column: "ProjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BTUserProject_Project_ProjectsId",
                table: "BTUserProject");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "BTUserProject",
                newName: "PorjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_BTUserProject_ProjectsId",
                table: "BTUserProject",
                newName: "IX_BTUserProject_PorjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BTUserProject_Project_PorjectsId",
                table: "BTUserProject",
                column: "PorjectsId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
