using Microsoft.EntityFrameworkCore.Migrations;

namespace UDEMY.CQRS.Migrations
{
    public partial class StudentDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "SurName" },
                values: new object[] { 1, 21, "Buse Nur", "Demirbaş" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "SurName" },
                values: new object[] { 2, 25, "Ayla", "Yıldız" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
