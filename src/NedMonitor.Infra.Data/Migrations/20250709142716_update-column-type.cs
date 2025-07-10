using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NedMonitor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatecolumntype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Notifications",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 4000);

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Notifications",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogMessage",
                table: "LogEntries",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 4000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Notifications",
                type: "varchar(150)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Detail",
                table: "Notifications",
                type: "varchar(150)",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LogMessage",
                table: "LogEntries",
                type: "varchar(150)",
                maxLength: 4000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");
        }
    }
}
