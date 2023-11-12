using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "area_academica",
                schema: "dbo",
                columns: table => new
                {
                    areaca_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    areaca_vcCodigo = table.Column<string>(type: "VARCHAR(4)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    areaca_vcNombre = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    areaca_bActivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area_academica", x => x.areaca_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_areaformativa",
                schema: "dbo",
                columns: table => new
                {
                    curare_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    curare_vcNombre = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_areaformativa", x => x.curare_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_tipo",
                schema: "dbo",
                columns: table => new
                {
                    curtip_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    curtip_vcNombre = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    curtip_bActivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_tipo", x => x.curtip_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_tipodictado",
                schema: "dbo",
                columns: table => new
                {
                    curtip_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    curtip_vcName = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_tipodictado", x => x.curtip_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dia",
                schema: "dbo",
                columns: table => new
                {
                    dia_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dia_iNumero = table.Column<int>(type: "int", nullable: false),
                    dia_vcNombre = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dia", x => x.dia_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "facultad",
                schema: "dbo",
                columns: table => new
                {
                    fac_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fac_vcCodigo = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fac_vcNombre = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facultad", x => x.fac_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "locales",
                schema: "dbo",
                columns: table => new
                {
                    loc_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    loc_vcCodigo = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    loc_vcNombre = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locales", x => x.loc_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "semestre",
                schema: "dbo",
                columns: table => new
                {
                    sem_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sem_vcCodigo = table.Column<string>(type: "VARCHAR(8)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sem_bActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semestre", x => x.sem_iCodigo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "escuela",
                schema: "dbo",
                columns: table => new
                {
                    esc_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    esc_vcCodigo = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    esc_vcNombre = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    esc_bActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    fac_iCodigo = table.Column<int>(type: "int", nullable: false),
                    areaca_iCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_escuela", x => x.esc_iCodigo);
                    table.ForeignKey(
                        name: "FK_escuela_area_academica_areaca_iCodigo",
                        column: x => x.areaca_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "area_academica",
                        principalColumn: "areaca_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_escuela_facultad_fac_iCodigo",
                        column: x => x.fac_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "facultad",
                        principalColumn: "fac_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "aula",
                schema: "dbo",
                columns: table => new
                {
                    aul_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    aul_vcCodigo = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    aul_iCapacidad = table.Column<int>(type: "int", nullable: false),
                    loc_iCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aula", x => x.aul_iCodigo);
                    table.ForeignKey(
                        name: "FK_aula_locales_loc_iCodigo",
                        column: x => x.loc_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "locales",
                        principalColumn: "loc_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plan_estudios",
                schema: "dbo",
                columns: table => new
                {
                    plaest_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    plaest_vcCodigo = table.Column<string>(type: "VARCHAR(8)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    plaest_vcRR = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    plaest_dVigencia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    plaest_iCreditos = table.Column<int>(type: "int", nullable: false),
                    plaest_bActivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plan_estudios", x => x.plaest_iCodigo);
                    table.ForeignKey(
                        name: "FK_plan_estudios_escuela_SchoolId",
                        column: x => x.SchoolId,
                        principalSchema: "dbo",
                        principalTable: "escuela",
                        principalColumn: "esc_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso",
                schema: "dbo",
                columns: table => new
                {
                    cur_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cur_vcCodigo = table.Column<string>(type: "VARCHAR(16)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cur_vcName = table.Column<string>(type: "VARCHAR(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cur_fCreditos = table.Column<decimal>(type: "DECIMAL(6,1)", nullable: false),
                    cur_fCreditosRequisito = table.Column<decimal>(type: "DECIMAL(6,1)", nullable: false),
                    cur_iSemestre = table.Column<int>(type: "int", nullable: false),
                    plaest_iCodigo = table.Column<int>(type: "int", nullable: false),
                    curtip_iCodigo = table.Column<int>(type: "int", nullable: false),
                    curare_iCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.cur_iCodigo);
                    table.ForeignKey(
                        name: "FK_curso_curso_areaformativa_curare_iCodigo",
                        column: x => x.curare_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso_areaformativa",
                        principalColumn: "curare_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_curso_curso_tipo_curtip_iCodigo",
                        column: x => x.curtip_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso_tipo",
                        principalColumn: "curtip_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_curso_plan_estudios_plaest_iCodigo",
                        column: x => x.plaest_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "plan_estudios",
                        principalColumn: "plaest_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_equivalente",
                schema: "dbo",
                columns: table => new
                {
                    cureqi_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cur_iCodigo = table.Column<int>(type: "int", nullable: false),
                    equ_iCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_equivalente", x => x.cureqi_iCodigo);
                    table.ForeignKey(
                        name: "FK_curso_equivalente_curso_cur_iCodigo",
                        column: x => x.cur_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso",
                        principalColumn: "cur_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_horasdictadas",
                schema: "dbo",
                columns: table => new
                {
                    curhor_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    curhor_iHoras = table.Column<int>(type: "int", nullable: false),
                    cur_iCodigo = table.Column<int>(type: "int", nullable: false),
                    curtip_iCogigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_horasdictadas", x => x.curhor_iCodigo);
                    table.ForeignKey(
                        name: "FK_curso_horasdictadas_curso_cur_iCodigo",
                        column: x => x.cur_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso",
                        principalColumn: "cur_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_curso_horasdictadas_curso_tipodictado_curtip_iCogigo",
                        column: x => x.curtip_iCogigo,
                        principalSchema: "dbo",
                        principalTable: "curso_tipodictado",
                        principalColumn: "curtip_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "curso_prerequisito",
                schema: "dbo",
                columns: table => new
                {
                    curpre_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cur_iCodigo = table.Column<int>(type: "int", nullable: false),
                    PrerequisiteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_prerequisito", x => x.curpre_iCodigo);
                    table.ForeignKey(
                        name: "FK_curso_prerequisito_curso_cur_iCodigo",
                        column: x => x.cur_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso",
                        principalColumn: "cur_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo",
                schema: "dbo",
                columns: table => new
                {
                    gru_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gru_iNumero = table.Column<int>(type: "int", nullable: false),
                    sem_iCodigo = table.Column<int>(type: "int", nullable: false),
                    cur_iCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.gru_iCodigo);
                    table.ForeignKey(
                        name: "FK_grupo_curso_cur_iCodigo",
                        column: x => x.cur_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso",
                        principalColumn: "cur_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_semestre_sem_iCodigo",
                        column: x => x.sem_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "semestre",
                        principalColumn: "sem_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo_horario",
                schema: "dbo",
                columns: table => new
                {
                    gruhor_iCodigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    gruhor_tHoraInicio = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    gruhor_tHoraFin = table.Column<TimeSpan>(type: "TIME", nullable: false),
                    gru_iCodigo = table.Column<int>(type: "int", nullable: false),
                    dia_iCodigo = table.Column<int>(type: "int", nullable: false),
                    aul_iCodigo = table.Column<int>(type: "int", nullable: false),
                    curtip_iCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_horario", x => x.gruhor_iCodigo);
                    table.ForeignKey(
                        name: "FK_grupo_horario_aula_aul_iCodigo",
                        column: x => x.aul_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "aula",
                        principalColumn: "aul_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_horario_curso_tipodictado_curtip_iCodigo",
                        column: x => x.curtip_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "curso_tipodictado",
                        principalColumn: "curtip_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_horario_dia_dia_iCodigo",
                        column: x => x.dia_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "dia",
                        principalColumn: "dia_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupo_horario_grupo_gru_iCodigo",
                        column: x => x.gru_iCodigo,
                        principalSchema: "dbo",
                        principalTable: "grupo",
                        principalColumn: "gru_iCodigo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_aula_loc_iCodigo",
                schema: "dbo",
                table: "aula",
                column: "loc_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_curare_iCodigo",
                schema: "dbo",
                table: "curso",
                column: "curare_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_curtip_iCodigo",
                schema: "dbo",
                table: "curso",
                column: "curtip_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_plaest_iCodigo",
                schema: "dbo",
                table: "curso",
                column: "plaest_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_equivalente_cur_iCodigo",
                schema: "dbo",
                table: "curso_equivalente",
                column: "cur_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_horasdictadas_cur_iCodigo",
                schema: "dbo",
                table: "curso_horasdictadas",
                column: "cur_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_horasdictadas_curtip_iCogigo",
                schema: "dbo",
                table: "curso_horasdictadas",
                column: "curtip_iCogigo");

            migrationBuilder.CreateIndex(
                name: "IX_curso_prerequisito_cur_iCodigo",
                schema: "dbo",
                table: "curso_prerequisito",
                column: "cur_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_escuela_areaca_iCodigo",
                schema: "dbo",
                table: "escuela",
                column: "areaca_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_escuela_fac_iCodigo",
                schema: "dbo",
                table: "escuela",
                column: "fac_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_cur_iCodigo",
                schema: "dbo",
                table: "grupo",
                column: "cur_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_sem_iCodigo",
                schema: "dbo",
                table: "grupo",
                column: "sem_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_horario_aul_iCodigo",
                schema: "dbo",
                table: "grupo_horario",
                column: "aul_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_horario_curtip_iCodigo",
                schema: "dbo",
                table: "grupo_horario",
                column: "curtip_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_horario_dia_iCodigo",
                schema: "dbo",
                table: "grupo_horario",
                column: "dia_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_grupo_horario_gru_iCodigo",
                schema: "dbo",
                table: "grupo_horario",
                column: "gru_iCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_plan_estudios_SchoolId",
                schema: "dbo",
                table: "plan_estudios",
                column: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "curso_equivalente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "curso_horasdictadas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "curso_prerequisito",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "grupo_horario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "aula",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "curso_tipodictado",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "dia",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "grupo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "locales",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "curso",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "semestre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "curso_areaformativa",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "curso_tipo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "plan_estudios",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "escuela",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "area_academica",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "facultad",
                schema: "dbo");
        }
    }
}
