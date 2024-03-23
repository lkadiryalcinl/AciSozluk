using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChannelUserRelationAndFollowChannelTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowChannels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChannelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowChannels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowChannels_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowChannels_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowChannels_ChannelId",
                table: "FollowChannels",
                column: "ChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowChannels_UserId",
                table: "FollowChannels",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowChannels");
        }
    }
}
