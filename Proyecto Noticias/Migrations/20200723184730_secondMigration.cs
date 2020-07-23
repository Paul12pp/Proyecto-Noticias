using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoNoticias.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Noticias_NoticiaId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "IdNoticia",
                table: "Comentarios");

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Noticias",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoticiaId",
                table: "Comentarios",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Comentarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Comentarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Comentarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Noticias_NoticiaId",
                table: "Comentarios",
                column: "NoticiaId",
                principalTable: "Noticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Noticias_NoticiaId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Noticias");

            migrationBuilder.AlterColumn<int>(
                name: "NoticiaId",
                table: "Comentarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Comentarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Comentarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Correo",
                table: "Comentarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "IdNoticia",
                table: "Comentarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Noticias_NoticiaId",
                table: "Comentarios",
                column: "NoticiaId",
                principalTable: "Noticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
