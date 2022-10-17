using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosApi.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "332902a5-0da6-42e4-8cdc-3c95d9f33d9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "71cffeef-9095-49ff-8fdc-ccad2514bbd6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5fab518-b574-48df-a986-524bf498a663", "AQAAAAEAACcQAAAAEPQwKXvcJ2L3e2ncGRHcAZxrwZn0R0jAGGzK34p0ot0+YeiOBD4EDc7LlrLME+03tw==", "b032a638-eb2e-47c7-ba62-23fbe4d99833" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999998,
                column: "ConcurrencyStamp",
                value: "1d147f6f-c2b8-4472-a814-f4edd863219a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 999999,
                column: "ConcurrencyStamp",
                value: "daf8abfc-4a9b-45f4-b7d0-a574a5bbf9af");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1736037a-2f06-4a37-a808-8b3c1e98b272", "AQAAAAEAACcQAAAAELcuxH1UA8QWu4v+86MPbCKQpk563Q037iXsXTJnn0zPwVEQexaaGmNMxJlyhg2g4g==", "6d8d7332-5f03-47e5-839d-83477fa79786" });
        }
    }
}
