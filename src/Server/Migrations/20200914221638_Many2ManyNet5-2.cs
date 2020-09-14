using Microsoft.EntityFrameworkCore.Migrations;

namespace MindPalace.Server.Migrations
{
    public partial class Many2ManyNet52 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTag_Links_LinkId",
                table: "LinkTag");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkTag_Tags_TagId",
                table: "LinkTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "LinkTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "LinkId",
                table: "LinkTag",
                newName: "LinksId");

            migrationBuilder.RenameIndex(
                name: "IX_LinkTag_TagId",
                table: "LinkTag",
                newName: "IX_LinkTag_TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTag_Links_LinksId",
                table: "LinkTag",
                column: "LinksId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTag_Tags_TagsId",
                table: "LinkTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkTag_Links_LinksId",
                table: "LinkTag");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkTag_Tags_TagsId",
                table: "LinkTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "LinkTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "LinksId",
                table: "LinkTag",
                newName: "LinkId");

            migrationBuilder.RenameIndex(
                name: "IX_LinkTag_TagsId",
                table: "LinkTag",
                newName: "IX_LinkTag_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTag_Links_LinkId",
                table: "LinkTag",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LinkTag_Tags_TagId",
                table: "LinkTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
