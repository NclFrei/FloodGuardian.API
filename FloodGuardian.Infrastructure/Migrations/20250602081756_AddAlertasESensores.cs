using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloodGuardian.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAlertasESensores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    SensorId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    NivelAgua = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Umidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Bateria = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SensorDataId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alertas_Sensor_SensorDataId",
                        column: x => x.SensorDataId,
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_SensorDataId",
                table: "Alertas",
                column: "SensorDataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "Sensor");
        }
    }
}
