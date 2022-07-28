using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBII.Migrations
{
    public partial class exclusaoTablePrerequisitoNovoRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prerequisitos");

            migrationBuilder.CreateTable(
                name: "DisciplinaDisciplina",
                columns: table => new
                {
                    DisciplinaRequeridaId = table.Column<int>(type: "int", nullable: false),
                    PrerequisitosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaDisciplina", x => new { x.DisciplinaRequeridaId, x.PrerequisitosId });
                    table.ForeignKey(
                        name: "FK_DisciplinaDisciplina_disciplinas_DisciplinaRequeridaId",
                        column: x => x.DisciplinaRequeridaId,
                        principalTable: "disciplinas",
                        principalColumn: "disciplina_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplinaDisciplina_disciplinas_PrerequisitosId",
                        column: x => x.PrerequisitosId,
                        principalTable: "disciplinas",
                        principalColumn: "disciplina_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaDisciplina_PrerequisitosId",
                table: "DisciplinaDisciplina",
                column: "PrerequisitosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaDisciplina");

            migrationBuilder.CreateTable(
                name: "prerequisitos",
                columns: table => new
                {
                    requisitos_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    requisitos_creditos = table.Column<int>(type: "int", nullable: false),
                    disciplina_id = table.Column<int>(type: "int", nullable: false),
                    disciplina_nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    requisitos_periodo = table.Column<int>(type: "int", nullable: false),
                    requisitos_disciplina = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prerequisitos", x => x.requisitos_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
