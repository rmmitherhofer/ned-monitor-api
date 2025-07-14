using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NedMonitor.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogAttentionLevel = table.Column<int>(type: "int", nullable: false),
                    CorrelationId = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    EndpointPath = table.Column<string>(type: "varchar(150)", maxLength: 9000, nullable: false),
                    TotalMilliseconds = table.Column<double>(type: "float", nullable: false),
                    TraceIdentifier = table.Column<string>(type: "varchar(150)", maxLength: 200, nullable: true),
                    ErrorCategory = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: true),
                    Project_Id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: false),
                    Project_Type = table.Column<int>(type: "int", nullable: false),
                    Project_Name = table.Column<string>(type: "varchar(150)", maxLength: 200, nullable: false),
                    Project_ExecutionMode_EnableNedMonitor = table.Column<bool>(type: "bit", nullable: false),
                    Project_ExecutionMode_EnableMonitorExceptions = table.Column<bool>(type: "bit", nullable: false),
                    Project_ExecutionMode_EnableMonitorNotifications = table.Column<bool>(type: "bit", nullable: false),
                    Project_ExecutionMode_EnableMonitorLogs = table.Column<bool>(type: "bit", nullable: false),
                    Project_ExecutionMode_EnableMonitorHttpRequests = table.Column<bool>(type: "bit", nullable: false),
                    Project_ExecutionMode_EnableMonitorDbQueries = table.Column<bool>(type: "bit", nullable: false),
                    Project_HttpLogging_WritePayloadToConsole = table.Column<bool>(type: "bit", nullable: true),
                    Project_HttpLogging_CaptureResponseBody = table.Column<bool>(type: "bit", nullable: true),
                    Project_HttpLogging_MaxResponseBodySizeInMb = table.Column<int>(type: "int", nullable: true),
                    Project_SensitiveDataMasking_Enabled = table.Column<bool>(type: "bit", nullable: true),
                    Project_SensitiveDataMasking_SensitiveKeys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_SensitiveDataMasking_MaskValue = table.Column<string>(type: "varchar(150)", nullable: true),
                    Project_Exceptions_Expected = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_DataInterceptors_EF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_DataInterceptors_Dapper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Project_MinimumLogLevel = table.Column<int>(type: "int", nullable: false),
                    Environment_MachineName = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: false),
                    Environment_EnvironmentName = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: false),
                    Environment_ApplicationVersion = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    Environment_ThreadId = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: true),
                    User_Name = table.Column<string>(type: "varchar(150)", maxLength: 450, nullable: true),
                    User_Account = table.Column<string>(type: "varchar(150)", nullable: true),
                    User_AccountCode = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: true),
                    User_Document = table.Column<string>(type: "varchar(150)", maxLength: 80, nullable: true),
                    User_Email = table.Column<string>(type: "varchar(150)", maxLength: 320, nullable: true),
                    User_TenantId = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: true),
                    User_IsAuthenticated = table.Column<bool>(type: "bit", nullable: false),
                    User_AuthenticationType = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: true),
                    User_Roles = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Claims = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request_Id = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    Request_HttpMethod = table.Column<string>(type: "varchar(150)", maxLength: 10, nullable: false),
                    Request_RequestUrl = table.Column<string>(type: "varchar(150)", maxLength: 1500, nullable: false),
                    Request_Scheme = table.Column<string>(type: "varchar(150)", maxLength: 20, nullable: false),
                    Request_Protocol = table.Column<string>(type: "varchar(150)", maxLength: 10, nullable: false),
                    Request_IsHttps = table.Column<bool>(type: "bit", nullable: false),
                    Request_QueryString = table.Column<string>(type: "varchar(150)", maxLength: 1350, nullable: false),
                    Request_RouteValues = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_ClientId = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: false),
                    Request_Headers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Request_ContentType = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: true),
                    Request_ContentLength = table.Column<long>(type: "bigint", nullable: true),
                    Request_Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Request_BodySize = table.Column<double>(type: "float", nullable: false),
                    Request_IsAjaxRequest = table.Column<bool>(type: "bit", nullable: false),
                    Request_IpAddress = table.Column<string>(type: "varchar(150)", maxLength: 45, nullable: true),
                    Request_UserPlatform_UserAgent = table.Column<string>(type: "varchar(150)", maxLength: 500, nullable: false),
                    Request_UserPlatform_BrowserName = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    Request_UserPlatform_BrowserVersion = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    Request_UserPlatform_OSName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Request_UserPlatform_OSVersion = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    Request_UserPlatform_DeviceType = table.Column<string>(type: "varchar(150)", maxLength: 50, nullable: false),
                    Response_StatusCode = table.Column<int>(type: "int", nullable: false),
                    Response_ReasonPhrase = table.Column<string>(type: "varchar(150)", maxLength: 450, nullable: false),
                    Response_Headers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Response_Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Response_BodySize = table.Column<long>(type: "bigint", nullable: false),
                    Diagnostic_MemoryUsageMb = table.Column<double>(type: "float", nullable: false),
                    Diagnostic_DbQueryCount = table.Column<int>(type: "int", nullable: false),
                    Diagnostic_CacheHit = table.Column<bool>(type: "bit", nullable: false),
                    Diagnostic_Dependencies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbQueryEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    Sql = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Parameters = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    ExecutedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationMs = table.Column<double>(type: "float", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    DbContext = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    ORM = table.Column<string>(type: "varchar(150)", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbQueryEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbQueryEntries_ApplicationLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "ApplicationLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exceptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "varchar(150)", maxLength: 500, nullable: false),
                    Message = table.Column<string>(type: "varchar(max)", nullable: false),
                    Tracer = table.Column<string>(type: "varchar(max)", nullable: true),
                    InnerException = table.Column<string>(type: "varchar(max)", nullable: true),
                    TimestampUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Source = table.Column<string>(type: "varchar(150)", maxLength: 250, nullable: true),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<string>(type: "varchar(150)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exceptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exceptions_ApplicationLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "ApplicationLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HttpClientLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<string>(type: "varchar(150)", maxLength: 10, nullable: false),
                    Url = table.Column<string>(type: "varchar(150)", maxLength: 2048, nullable: false),
                    UrlTemplate = table.Column<string>(type: "varchar(150)", maxLength: 2048, nullable: true),
                    StatusCode = table.Column<int>(type: "int", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseHeaders = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionType = table.Column<string>(type: "varchar(150)", maxLength: 500, nullable: true),
                    ExceptionMessage = table.Column<string>(type: "varchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "varchar(max)", nullable: true),
                    InnerException = table.Column<string>(type: "varchar(max)", nullable: true),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<string>(type: "varchar(150)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "LogEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogCategory = table.Column<string>(type: "varchar(150)", maxLength: 4000, nullable: false),
                    LogSeverity = table.Column<int>(type: "int", nullable: false),
                    LogMessage = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    MemberType = table.Column<string>(type: "varchar(150)", nullable: true),
                    MemberName = table.Column<string>(type: "varchar(150)", maxLength: 450, nullable: true),
                    SourceLineNumber = table.Column<int>(type: "int", nullable: false),
                    TimestampUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CorrelationId = table.Column<string>(type: "varchar(150)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogEntries_ApplicationLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "ApplicationLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogLevel = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "varchar(150)", maxLength: 350, nullable: true),
                    Value = table.Column<string>(type: "VARCHAR(MAX)", nullable: false),
                    Detail = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    CorrelationId = table.Column<string>(type: "varchar(150)", nullable: false),
                    LogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_ApplicationLogs_LogId",
                        column: x => x.LogId,
                        principalTable: "ApplicationLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_CorrelationId",
                table: "ApplicationLogs",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_EndpointPath",
                table: "ApplicationLogs",
                column: "EndpointPath");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_Environment_MachineName",
                table: "ApplicationLogs",
                column: "Environment_MachineName");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_ErrorCategory",
                table: "ApplicationLogs",
                column: "ErrorCategory");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_Project_Id",
                table: "ApplicationLogs",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_Project_Name",
                table: "ApplicationLogs",
                column: "Project_Name");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_Project_Type",
                table: "ApplicationLogs",
                column: "Project_Type");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_Request_ClientId",
                table: "ApplicationLogs",
                column: "Request_ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_Request_Id",
                table: "ApplicationLogs",
                column: "Request_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_User_AccountCode",
                table: "ApplicationLogs",
                column: "User_AccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_User_Document",
                table: "ApplicationLogs",
                column: "User_Document");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_User_Id",
                table: "ApplicationLogs",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLogs_User_Name",
                table: "ApplicationLogs",
                column: "User_Name");

            migrationBuilder.CreateIndex(
                name: "IX_DbQueryEntries_LogId",
                table: "DbQueryEntries",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Exceptions_LogId",
                table: "Exceptions",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_HttpClientLogs_LogId",
                table: "HttpClientLogs",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_LogEntries_LogId",
                table: "LogEntries",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LogId",
                table: "Notifications",
                column: "LogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbQueryEntries");

            migrationBuilder.DropTable(
                name: "Exceptions");

            migrationBuilder.DropTable(
                name: "HttpClientLogs");

            migrationBuilder.DropTable(
                name: "LogEntries");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ApplicationLogs");
        }
    }
}
