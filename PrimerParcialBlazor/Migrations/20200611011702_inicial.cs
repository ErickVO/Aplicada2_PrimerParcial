using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimerParcialBlazor.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(maxLength: 40, nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    ValorInventario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.ArticuloId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}
