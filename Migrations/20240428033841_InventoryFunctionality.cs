using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Almacenes.Migrations
{
    /// <inheritdoc />
    public partial class InventoryFunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatUM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Existencia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    MovimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MovAlmId = table.Column<int>(type: "int", nullable: false),
                    MovMatId = table.Column<int>(type: "int", nullable: false),
                    MovQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estantes = table.Column<int>(type: "int", nullable: false),
                    Niveles = table.Column<int>(type: "int", nullable: false),
                    Cajas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.MovimientoId);
                    table.ForeignKey(
                        name: "FK_Movimientos_Almacen_MovAlmId",
                        column: x => x.MovAlmId,
                        principalTable: "Almacen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_Materiales_MovMatId",
                        column: x => x.MovMatId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_MovAlmId",
                table: "Movimientos",
                column: "MovAlmId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_MovMatId",
                table: "Movimientos",
                column: "MovMatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "Materiales");
        }
    }
}
