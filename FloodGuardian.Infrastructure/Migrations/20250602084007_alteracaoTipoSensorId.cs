using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloodGuardian.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoTipoSensorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "Sensor",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "RAW(16)");

            migrationBuilder.AlterColumn<string>(
                name: "SensorId",
                table: "Alertas",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "RAW(16)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SensorId",
                table: "Sensor",
                type: "RAW(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<Guid>(
                name: "SensorId",
                table: "Alertas",
                type: "RAW(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }
    }
}
