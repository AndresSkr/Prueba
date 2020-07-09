using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaP.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIT = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(nullable: true),
                    correo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombrePais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servicios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreServicio = table.Column<string>(nullable: true),
                    valorxHora = table.Column<decimal>(nullable: false),
                    fk_ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicios_clientes_fk_ClienteId",
                        column: x => x.fk_ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "servicios_pais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fk_IdPaisId = table.Column<int>(nullable: true),
                    fK_IdServicioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicios_pais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicios_pais_servicios_fK_IdServicioId",
                        column: x => x.fK_IdServicioId,
                        principalTable: "servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_servicios_pais_paises_fk_IdPaisId",
                        column: x => x.fk_IdPaisId,
                        principalTable: "paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_servicios_fk_ClienteId",
                table: "servicios",
                column: "fk_ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_pais_fK_IdServicioId",
                table: "servicios_pais",
                column: "fK_IdServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_servicios_pais_fk_IdPaisId",
                table: "servicios_pais",
                column: "fk_IdPaisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servicios_pais");

            migrationBuilder.DropTable(
                name: "servicios");

            migrationBuilder.DropTable(
                name: "paises");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
