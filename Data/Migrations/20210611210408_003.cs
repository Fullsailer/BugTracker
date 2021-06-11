using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Data.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_AspNetUsers_InvitorId1",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachment_AspNetUsers_UserId1",
                table: "TicketAttachment");

            migrationBuilder.DropIndex(
                name: "IX_TicketAttachment_UserId1",
                table: "TicketAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Invite_InvitorId1",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TicketAttachment");

            migrationBuilder.DropColumn(
                name: "InviteeFristName",
                table: "Invite");

            migrationBuilder.RenameColumn(
                name: "InvitorId1",
                table: "Invite",
                newName: "InviteeFirstName");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "TicketType",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyToken",
                table: "TicketType",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "InviteDate",
                table: "TicketType",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "InviteeEmail",
                table: "TicketType",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invitor",
                table: "TicketType",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "TicketType",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Project",
                table: "TicketType",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TicketAttachment",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "InvitorId",
                table: "Invite",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachment_UserId",
                table: "TicketAttachment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_InvitorId",
                table: "Invite",
                column: "InvitorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_AspNetUsers_InvitorId",
                table: "Invite",
                column: "InvitorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachment_AspNetUsers_UserId",
                table: "TicketAttachment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_AspNetUsers_InvitorId",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketAttachment_AspNetUsers_UserId",
                table: "TicketAttachment");

            migrationBuilder.DropIndex(
                name: "IX_TicketAttachment_UserId",
                table: "TicketAttachment");

            migrationBuilder.DropIndex(
                name: "IX_Invite_InvitorId",
                table: "Invite");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "CompanyToken",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "InviteDate",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "InviteeEmail",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "Invitor",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "Project",
                table: "TicketType");

            migrationBuilder.RenameColumn(
                name: "InviteeFirstName",
                table: "Invite",
                newName: "InvitorId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TicketAttachment",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TicketAttachment",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InvitorId",
                table: "Invite",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InviteeFristName",
                table: "Invite",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachment_UserId1",
                table: "TicketAttachment",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Invite_InvitorId1",
                table: "Invite",
                column: "InvitorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_AspNetUsers_InvitorId1",
                table: "Invite",
                column: "InvitorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketAttachment_AspNetUsers_UserId1",
                table: "TicketAttachment",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
