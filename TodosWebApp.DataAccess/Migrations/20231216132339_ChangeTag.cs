using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodosWebApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_TagTypes_TagTypesId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_TagTypesId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "TagTypesId",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "TagTypesId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_TagTypesId",
                table: "Tags",
                column: "TagTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_TagTypes_TagTypesId",
                table: "Tags",
                column: "TagTypesId",
                principalTable: "TagTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
