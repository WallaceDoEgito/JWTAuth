using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarotraumaJWT.Migrations
{
    /// <inheritdoc />
    public partial class FixTypos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "LoginName");

            migrationBuilder.RenameColumn(
                name: "Profision",
                table: "Characters",
                newName: "Profission");

            migrationBuilder.AddColumn<Guid>(
                name: "SubmarineId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Submarines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submarines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SubmarineId",
                table: "Characters",
                column: "SubmarineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Submarines_SubmarineId",
                table: "Characters",
                column: "SubmarineId",
                principalTable: "Submarines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Submarines_SubmarineId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Submarines");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SubmarineId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SubmarineId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "LoginName",
                table: "Users",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Profission",
                table: "Characters",
                newName: "Profision");
        }
    }
}
