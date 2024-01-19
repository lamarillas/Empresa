using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empleados.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    Estatus_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.Estatus_Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Empleado_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido_Paterno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido_Materno = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "Date", nullable: false),
                    Estatus_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Empleado_Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Estatus_Estatus_Id",
                        column: x => x.Estatus_Id,
                        principalTable: "Estatus",
                        principalColumn: "Estatus_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estatus",
                columns: new[] { "Estatus_Id", "Descripcion" },
                values: new object[] { 1, "Activo" });

            migrationBuilder.InsertData(
                table: "Estatus",
                columns: new[] { "Estatus_Id", "Descripcion" },
                values: new object[] { 2, "No Activo" });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_Estatus_Id",
                table: "Empleados",
                column: "Estatus_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
