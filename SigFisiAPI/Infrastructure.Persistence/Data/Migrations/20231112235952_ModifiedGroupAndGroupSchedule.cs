using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedGroupAndGroupSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gruhor_iTope",
                schema: "dbo",
                table: "grupo_horario");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "dbo",
                table: "grupo");

            migrationBuilder.AddColumn<int>(
                name: "cur_iTope",
                schema: "dbo",
                table: "grupo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cur_iTope",
                schema: "dbo",
                table: "grupo");

            migrationBuilder.AddColumn<int>(
                name: "gruhor_iTope",
                schema: "dbo",
                table: "grupo_horario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "grupo",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
