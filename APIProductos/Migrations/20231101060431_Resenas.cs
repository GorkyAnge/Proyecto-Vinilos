using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIProductos.Migrations
{
    /// <inheritdoc />
    public partial class Resenas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Compras_CompraIdCarrito",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Productos_CompraIdCarrito",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CompraIdCarrito",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "Resenas",
                columns: table => new
                {
                    IdResena = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ViniloId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resenas", x => x.IdResena);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resenas");

            migrationBuilder.AddColumn<int>(
                name: "CompraIdCarrito",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    IdCarrito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.IdCarrito);
                });

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompraIdCarrito",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CompraIdCarrito",
                table: "Productos",
                column: "CompraIdCarrito");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Compras_CompraIdCarrito",
                table: "Productos",
                column: "CompraIdCarrito",
                principalTable: "Compras",
                principalColumn: "IdCarrito");
        }
    }
}
