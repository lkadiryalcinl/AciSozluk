using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChannelUserRelationAndFollowChannelTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowChannels_AspNetUsers_UserId",
                table: "FollowChannels");

            migrationBuilder.DropIndex(
                name: "IX_FollowChannels_ChannelId",
                table: "FollowChannels");

            migrationBuilder.CreateIndex(
                name: "IX_FollowChannels_ChannelId",
                table: "FollowChannels",
                column: "ChannelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowChannels_AspNetUsers_UserId",
                table: "FollowChannels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowChannels_AspNetUsers_UserId",
                table: "FollowChannels");

            migrationBuilder.DropIndex(
                name: "IX_FollowChannels_ChannelId",
                table: "FollowChannels");

            migrationBuilder.CreateIndex(
                name: "IX_FollowChannels_ChannelId",
                table: "FollowChannels",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowChannels_AspNetUsers_UserId",
                table: "FollowChannels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
