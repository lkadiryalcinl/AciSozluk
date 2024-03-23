using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class followUserAndUserRelationAndFollowUserDbSet2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FollowUsers_AspNetUsers_FollowedId",
                table: "FollowUsers");

            migrationBuilder.DropIndex(
                name: "IX_FollowUsers_FollowedId",
                table: "FollowUsers");

            migrationBuilder.AlterColumn<string>(
                name: "FollowedId",
                table: "FollowUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FollowedId",
                table: "FollowUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUsers_FollowedId",
                table: "FollowUsers",
                column: "FollowedId");

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUsers_AspNetUsers_FollowedId",
                table: "FollowUsers",
                column: "FollowedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
