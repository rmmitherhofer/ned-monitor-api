using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NedMonitor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullablerequestContentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Request_ContentType",
                table: "ApplicationLogs",
                type: "varchar(150)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Request_ContentType",
                table: "ApplicationLogs",
                type: "varchar(150)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
