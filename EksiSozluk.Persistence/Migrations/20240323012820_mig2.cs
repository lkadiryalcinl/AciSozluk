using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Titles_ChannelId",
                table: "Titles",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Channels_ChannelId",
                table: "Titles",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Channels_ChannelId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_ChannelId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Titles");
        }
    }
}
