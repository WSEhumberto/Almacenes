using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Almacenes.Migrations
{
    /// <inheritdoc />
    public partial class addingMaterialCodeToMaterialEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatCode",
                table: "Materiales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatCode",
                table: "Materiales");
        }
    }
}
