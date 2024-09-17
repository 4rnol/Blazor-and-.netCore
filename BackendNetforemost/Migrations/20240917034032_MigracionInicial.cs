using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendNetforemost.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    Eliminado = table.Column<bool>(type: "bit", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PrioridadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Prioridades_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tareas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Prioridades",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Alta" },
                    { 2, "Media" },
                    { 3, "Baja" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellido", "Correo", "Created_At", "Nombre", "Telefono", "Updated_At" },
                values: new object[,]
                {
                    { 1, "Perez", "juan@asd.asd", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7505), "Juan", "123456789", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7513) },
                    { 2, "Gomez", "maria@asdas.asd", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7514), "Maria", "987654321", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7515) }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "Created_At", "Descripcion", "Eliminado", "FechaVencimiento", "Finalizado", "PrioridadId", "Tags", "Titulo", "Updated_At", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7611), "Descripcion de la tarea 1", false, new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7610), false, 1, "tag1, tag2", "Tarea 1", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7611), 1 },
                    { 2, new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7614), "Descripcion de la tarea 2", false, new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7613), false, 2, "tag1, tag2", "Tarea 2", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7614), 1 },
                    { 3, new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7616), "Descripcion de la tarea 3", false, new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7615), false, 3, "tag1, tag2", "Tarea 3", new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7616), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_PrioridadId",
                table: "Tareas",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_UsuarioId",
                table: "Tareas",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
