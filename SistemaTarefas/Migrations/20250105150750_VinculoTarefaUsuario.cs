using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaTarefas.Migrations
{
    /// <inheritdoc />
    public partial class VinculoTarefaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "tarefas",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "tarefas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_UsuarioId",
                table: "tarefas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_tarefas_usuarios_UsuarioId",
                table: "tarefas",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tarefas_usuarios_UsuarioId",
                table: "tarefas");

            migrationBuilder.DropIndex(
                name: "IX_tarefas_UsuarioId",
                table: "tarefas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "tarefas");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tarefas",
                newName: "status");
        }
    }
}
