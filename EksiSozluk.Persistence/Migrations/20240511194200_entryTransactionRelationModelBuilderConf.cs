using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entryTransactionRelationModelBuilderConf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryTransactionRelations_AspNetUsers_UserId",
                table: "EntryTransactionRelations");

            migrationBuilder.DropIndex(
                name: "IX_EntryTransactionRelations_UserId",
                table: "EntryTransactionRelations");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTransactionRelations_UserId",
                table: "EntryTransactionRelations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntryTransactionRelations_AspNetUsers_UserId",
                table: "EntryTransactionRelations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntryTransactionRelations_AspNetUsers_UserId",
                table: "EntryTransactionRelations");

            migrationBuilder.DropIndex(
                name: "IX_EntryTransactionRelations_UserId",
                table: "EntryTransactionRelations");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTransactionRelations_UserId",
                table: "EntryTransactionRelations",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryTransactionRelations_AspNetUsers_UserId",
                table: "EntryTransactionRelations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
