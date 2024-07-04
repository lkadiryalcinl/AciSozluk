using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FollowTitleUserRelationAndFollowTitleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_UserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "IsFollowed",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Titles");

            migrationBuilder.CreateTable(
                name: "FollowTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowTitles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FollowTitles_Titles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowTitles_TitleId",
                table: "FollowTitles",
                column: "TitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FollowTitles_UserId",
                table: "FollowTitles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowTitles");

            migrationBuilder.AddColumn<bool>(
                name: "IsFollowed",
                table: "Titles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Titles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_UserId",
                table: "Titles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_UserId",
                table: "Titles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
