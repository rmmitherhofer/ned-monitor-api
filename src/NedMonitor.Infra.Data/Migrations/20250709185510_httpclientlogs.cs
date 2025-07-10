using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NedMonitor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class httpclientlogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Exceptions",
                type: "varchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<string>(
                name: "InnerException",
                table: "Exceptions",
                type: "varchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "HttpClientLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "varchar(150)", maxLength: 10, nullable: false),
                    Url = table.Column<string>(type: "varchar(150)", maxLength: 2048, nullable: false),
                    UrlTemplate = table.Column<string>(type: "varchar(150)", maxLength: 2048, nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    RequestBody = table.Column<string>(type: "varchar(max)", nullable: true),
                    RequestHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "varchar(max)", nullable: true),
                    ResponseHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionType = table.Column<string>(type: "varchar(150)", maxLength: 500, nullable: true),
                    ExceptionMessage = table.Column<string>(type: "varchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "varchar(max)", nullable: true),
                    InnerException = table.Column<string>(type: "varchar(max)", nullable: true),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HttpClientLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HttpClientLogs_ApplicationLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "ApplicationLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HttpClientLogs_LogId",
                table: "HttpClientLogs",
                column: "LogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HttpClientLogs");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Exceptions",
                type: "varchar(150)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "InnerException",
                table: "Exceptions",
                type: "varchar(150)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldNullable: true);
        }
    }
}
