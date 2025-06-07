using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiEmpresasProductos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroSucursales = table.Column<int>(type: "int", nullable: false),
                    NumeroEmpleados = table.Column<int>(type: "int", nullable: false),
                    Sector = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empresas",
                columns: new[] { "Id", "Nombre", "NumeroEmpleados", "NumeroSucursales", "Pais", "Sector" },
                values: new object[,]
                {
                    { 1, "TechCorp", 1000, 5, "USA", "Tecnología" },
                    { 2, "AgroPlus", 300, 2, "Argentina", "Agroindustria" },
                    { 3, "ConstruMax", 450, 4, "México", "Construcción" },
                    { 4, "MediSalud", 500, 3, "Colombia", "Salud" },
                    { 5, "EcoEnergy", 150, 1, "Chile", "Energía" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "Costo", "Descripcion", "EmpresaId", "Nombre" },
                values: new object[,]
                {
                    { 1, 300m, "Panel de alta eficiencia", 5, "Panel Solar" },
                    { 2, 1200m, "ERP para empresas medianas", 1, "Software ERP" },
                    { 3, 8000m, "Tractor con GPS", 2, "Tractor X200" },
                    { 4, 50m, "Certificación internacional", 3, "Casco de seguridad" },
                    { 5, 3m, "Fórmula pediátrica", 4, "Suero Oral" },
                    { 6, 400m, "Andamio de aluminio", 3, "Andamio modular" },
                    { 7, 900m, "CRM multiusuario", 1, "CRM Web" },
                    { 8, 10000m, "Turbina de baja velocidad", 5, "Generador eólico" },
                    { 9, 2500m, "Alta precisión", 2, "Pulverizador agrícola" },
                    { 10, 80m, "Para uso clínico", 4, "Tensiómetro digital" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EmpresaId",
                table: "Productos",
                column: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
