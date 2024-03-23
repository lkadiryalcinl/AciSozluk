using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChannelId",
                table: "Titles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Titles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "TitleId",
                table: "Entries",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Entries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_ChannelId",
                table: "Titles",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_UserId",
                table: "Titles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TitleId",
                table: "Entries",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_UserId",
                table: "Entries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_UserId",
                table: "Entries",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Titles_TitleId",
                table: "Entries",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Channels_ChannelId",
                table: "Titles",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_UserId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Titles_TitleId",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles");

            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Channels_ChannelId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_ChannelId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_UserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Entries_TitleId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_UserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Entries");
        }
    }
}
