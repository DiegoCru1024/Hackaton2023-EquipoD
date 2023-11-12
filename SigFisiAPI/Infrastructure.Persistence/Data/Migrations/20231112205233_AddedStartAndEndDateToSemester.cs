using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedStartAndEndDateToSemester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "sem_dFechaFin",
                schema: "dbo",
                table: "semestre",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "sem_dFechaInicio",
                schema: "dbo",
                table: "semestre",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "plaest_dVigencia",
                schema: "dbo",
                table: "plan_estudios",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sem_dFechaFin",
                schema: "dbo",
                table: "semestre");

            migrationBuilder.DropColumn(
                name: "sem_dFechaInicio",
                schema: "dbo",
                table: "semestre");

            migrationBuilder.AlterColumn<DateTime>(
                name: "plaest_dVigencia",
                schema: "dbo",
                table: "plan_estudios",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");
        }
    }
}
