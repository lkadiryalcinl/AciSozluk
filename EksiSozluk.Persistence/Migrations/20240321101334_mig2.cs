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
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Channels_ChannelID",
                table: "Titles");

            migrationBuilder.RenameColumn(
                name: "ChannelID",
                table: "Titles",
                newName: "ChannelId");

            migrationBuilder.RenameIndex(
                name: "IX_Titles_ChannelID",
                table: "Titles",
                newName: "IX_Titles_ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Channels_ChannelId",
                table: "Titles",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Channels_ChannelId",
                table: "Titles");

            migrationBuilder.RenameColumn(
                name: "ChannelId",
                table: "Titles",
                newName: "ChannelID");

            migrationBuilder.RenameIndex(
                name: "IX_Titles_ChannelId",
                table: "Titles",
                newName: "IX_Titles_ChannelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Channels_ChannelID",
                table: "Titles",
                column: "ChannelID",
                principalTable: "Channels",
                principalColumn: "ChannelID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
