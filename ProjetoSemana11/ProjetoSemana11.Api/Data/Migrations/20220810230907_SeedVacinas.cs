using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoSemana11.Api.Data.Migrations
{
    public partial class SeedVacinas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vacinas",
                columns: new[] { "Id", "Nome", "NumeroDoses" },
                values: new object[] { 1, "Gripe", 1 });

            migrationBuilder.InsertData(
                table: "Vacinas",
                columns: new[] { "Id", "Nome", "NumeroDoses" },
                values: new object[] { 2, "Tétano", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vacinas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vacinas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
