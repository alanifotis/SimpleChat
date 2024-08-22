using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleChat.Migrations
{
    /// <inheritdoc />
    public partial class NewUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_message_user_UserId",
                table: "message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_message",
                table: "message");

            migrationBuilder.RenameTable(
                name: "message",
                newName: "ChatMessages");

            migrationBuilder.RenameIndex(
                name: "IX_message_UserId",
                table: "ChatMessages",
                newName: "IX_ChatMessages_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMessages_user_UserId",
                table: "ChatMessages",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMessages_user_UserId",
                table: "ChatMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChatMessages",
                table: "ChatMessages");

            migrationBuilder.RenameTable(
                name: "ChatMessages",
                newName: "message");

            migrationBuilder.RenameIndex(
                name: "IX_ChatMessages_UserId",
                table: "message",
                newName: "IX_message_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_message",
                table: "message",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_UserId",
                table: "message",
                column: "UserId",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
