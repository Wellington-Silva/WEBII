using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBII.Migrations
{
    public partial class novaTabelaPrerequisito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaDisciplina");

            migrationBuilder.CreateTable(
                name: "Prerequisito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DisciplinaRequeridaId = table.Column<int>(type: "int", nullable: false),
                    PrerequisitoDisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prerequisito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prerequisito_disciplinas_DisciplinaRequeridaId",
                        column: x => x.DisciplinaRequeridaId,
                        principalTable: "disciplinas",
                        principalColumn: "disciplina_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prerequisito_disciplinas_PrerequisitoDisciplinaId",
                        column: x => x.PrerequisitoDisciplinaId,
                        principalTable: "disciplinas",
                        principalColumn: "disciplina_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisito_DisciplinaRequeridaId",
                table: "Prerequisito",
                column: "DisciplinaRequeridaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisito_PrerequisitoDisciplinaId",
                table: "Prerequisito",
                column: "PrerequisitoDisciplinaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prerequisito");

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
    }
}
