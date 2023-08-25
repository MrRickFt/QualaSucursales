using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndSucursales.Migrations
{
    /// <inheritdoc />
    public partial class QualaDB_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monedas_Quala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMoneda = table.Column<string>(type: "varchar(10)", nullable: false),
                    DescripcionMoneda = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas_Quala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios_Quala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios_Quala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal_Quala",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(250)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(250)", nullable: false),
                    Identificacion = table.Column<string>(type: "varchar(50)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    MonedaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal_Quala", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sucursal_Quala_Monedas_Quala_MonedaId",
                        column: x => x.MonedaId,
                        principalTable: "Monedas_Quala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_Quala_MonedaId",
                table: "Sucursal_Quala",
                column: "MonedaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursal_Quala");

            migrationBuilder.DropTable(
                name: "Usuarios_Quala");

            migrationBuilder.DropTable(
                name: "Monedas_Quala");
        }
    }
}
