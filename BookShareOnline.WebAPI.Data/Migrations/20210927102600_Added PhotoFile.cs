using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShareOnline.WebAPI.Data.Migrations
{
    public partial class AddedPhotoFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoFileName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoFileName",
                table: "Books");
        }
    }
}
