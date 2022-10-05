using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorRH.App.Persistencia.Migrations
{
    public partial class Inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Cargo",
                table: "Trabajadores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Cargo",
                table: "Trabajadores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
