using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBII.Migrations
{
    public partial class atualizandoModelDisciplinaParaValidacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "disciplina_categoria",
                table: "disciplinas");

            migrationBuilder.UpdateData(
                table: "disciplinas",
                keyColumn: "disciplina_nome",
                keyValue: null,
                column: "disciplina_nome",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "disciplina_nome",
                table: "disciplinas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "categoriaId",
                table: "disciplinas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_disciplinas_categoriaId",
                table: "disciplinas",
                column: "categoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_disciplinas_categoria_categoriaId",
                table: "disciplinas",
                column: "categoriaId",
                principalTable: "categoria",
                principalColumn: "categoria_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_disciplinas_categoria_categoriaId",
                table: "disciplinas");

            migrationBuilder.DropIndex(
                name: "IX_disciplinas_categoriaId",
                table: "disciplinas");

            migrationBuilder.DropColumn(
                name: "categoriaId",
                table: "disciplinas");

            migrationBuilder.AlterColumn<string>(
                name: "disciplina_nome",
                table: "disciplinas",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "disciplina_categoria",
                table: "disciplinas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
