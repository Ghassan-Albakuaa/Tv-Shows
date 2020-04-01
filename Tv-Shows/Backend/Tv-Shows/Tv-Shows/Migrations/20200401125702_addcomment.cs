using Microsoft.EntityFrameworkCore.Migrations;

namespace Tv_Shows.Migrations
{
    public partial class addcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "Rating", "TvshowId", "UserId" },
                values: new object[] { 1, "Ghassan", "5", 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
