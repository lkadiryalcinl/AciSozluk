using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserEntryEntryTransactionAndEntryTransactionRelationAndEntryTransactionAndEntryTransactionRelationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteCount",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "IsEntryDisliked",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "IsEntryFavorited",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "IsEntryLiked",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "LikeCount",
                table: "Entries");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Entries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EntryTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LikedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisikedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFavorited = table.Column<bool>(type: "bit", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false),
                    IsDisliked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTransactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntryTransactionRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryTransactionRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryTransactionRelations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntryTransactionRelations_Entries_EntryId",
                        column: x => x.EntryId,
                        principalTable: "Entries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntryTransactionRelations_EntryTransactions_EntryTransactionId",
                        column: x => x.EntryTransactionId,
                        principalTable: "EntryTransactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntryTransactionRelations_EntryId",
                table: "EntryTransactionRelations",
                column: "EntryId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryTransactionRelations_EntryTransactionId",
                table: "EntryTransactionRelations",
                column: "EntryTransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntryTransactionRelations_UserId",
                table: "EntryTransactionRelations",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntryTransactionRelations");

            migrationBuilder.DropTable(
                name: "EntryTransactions");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Entries");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCount",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEntryDisliked",
                table: "Entries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEntryFavorited",
                table: "Entries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEntryLiked",
                table: "Entries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LikeCount",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
