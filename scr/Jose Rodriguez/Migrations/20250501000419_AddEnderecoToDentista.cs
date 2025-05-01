using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jose_Rodriguez.Migrations
{
    public partial class AddEnderecoToDentista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dentistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dentistas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dentistas",
                columns: new[] { "Id", "Cedula", "Email", "Nome", "Telefone" },
                values: new object[] { 1, "123456", "maria.silva@odontovip.com", "Dr. Maria Silva", "(11) 98765-4321" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "NameUser",
                value: "Dr. José Rodriguez");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dentistas");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "NameUser",
                value: "Dr.José Rodriguez");
        }
    }
}
