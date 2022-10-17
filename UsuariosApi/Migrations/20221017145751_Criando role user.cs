using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class Criandoroleuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "daf8abfc-4a9b-45f4-b7d0-a574a5bbf9af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 999998, "1d147f6f-c2b8-4472-a814-f4edd863219a", "user", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1736037a-2f06-4a37-a808-8b3c1e98b272", "AQAAAAEAACcQAAAAELcuxH1UA8QWu4v+86MPbCKQpk563Q037iXsXTJnn0zPwVEQexaaGmNMxJlyhg2g4g==", "6d8d7332-5f03-47e5-839d-83477fa79786" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "5cf749a5-88a9-427c-a195-ebe5d411c978");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf672336-77ae-4c75-b266-f27b22172228", "AQAAAAEAACcQAAAAEETtuBYQWR3iVtwr2ydtAxn5bcI7zCNpGnhQFqbnu+uTiRXt/3OLxPiyXXtZdF6R6A==", "cb9b6115-f701-4be7-acc3-e7e5fc745879" });
        }
    }
}
