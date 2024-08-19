using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleChat.Migrations
{
    /// <inheritdoc />
    public partial class ModelV0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_user_UserId",
                table: "ChatMessages");

            migrationBuilder.DropColumn(
                name: "user_chat_message",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ChatMessages",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ChatMessages",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "ChatMessages",
                newName: "chat_message");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_UserId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_user_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "ChatMessages",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "chat_message",
                table: "ChatMessages",
                type: "VARCHAR(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_user_user_id",
                table: "ChatMessages",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_user_user_id",
                table: "ChatMessages");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ChatMessages",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "ChatMessages",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "chat_message",
                table: "ChatMessages",
                newName: "Message");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_user_id",
                table: "ChatMessages",
                newName: "IX_ChatMessages_UserId");

            migrationBuilder.AddColumn<string>(
                name: "user_chat_message",
                table: "user",
                type: "VARCHAR(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ChatMessages",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ChatMessages",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(255)");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_user_UserId",
                table: "ChatMessages",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
