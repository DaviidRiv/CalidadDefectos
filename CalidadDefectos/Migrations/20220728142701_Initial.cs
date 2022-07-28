using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalidadDefectos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Formulario_Model",
                columns: table => new
                {
                    ID_Form = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Semana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Anio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MesAnio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ensamble = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamanio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deteccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pareto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParetoSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Componente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Elemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remaches = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentarios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formulario_Model", x => x.ID_Form);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Formulario_Model");
        }
    }
}
