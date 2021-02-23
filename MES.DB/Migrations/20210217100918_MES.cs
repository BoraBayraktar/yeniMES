using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AD_CUSTOMERS",
                columns: table => new
                {
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AD_CUSTOMERS", x => x.CUSTOMER_ID);
                });

            migrationBuilder.CreateTable(
                name: "COUNTRY",
                columns: table => new
                {
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUNTRY", x => x.COUNTRY_ID);
                });

            migrationBuilder.CreateTable(
                name: "DOMAIN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOMAIN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GENERAL_SETTINGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOGIN_PAGE_BACKGROUND = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LOGIN_PAGE_TEXT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LOGO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENERAL_SETTINGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GROUP_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INCIDENT_TYPE",
                columns: table => new
                {
                    INCIDENT_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCIDENT_TYPE", x => x.INCIDENT_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LDAP_INFO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortNumber = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SearchBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CronType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DailyTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    DayOfMonth = table.Column<int>(type: "int", nullable: false),
                    OneTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelectedOu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LDAP_INFO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LEAVE_TYPE",
                columns: table => new
                {
                    LEAVE_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVE_TYPE", x => x.LEAVE_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "LOGGER_REQUEST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTROLLER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PATH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSONDATA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGGER_REQUEST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOGGER_RESPONSE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REQUEST_ID = table.Column<int>(type: "int", nullable: false),
                    CONTROLLER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PATH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    METHOD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JSONDATA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGGER_RESPONSE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MAIL_SERVER_SETUP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SMTP_HOST = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SMTP_PORT = table.Column<int>(type: "int", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEFAULT_ADDRESS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DEFAULT_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TRY_COUNT = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIL_SERVER_SETUP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MAIL_TO_SEND",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TO_ADDRESS = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MAIL_SUBJECT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAIL_BODY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_SENT = table.Column<bool>(type: "bit", nullable: false),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: true),
                    PARAMETER_ID = table.Column<int>(type: "int", nullable: true),
                    PARAMETER_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIL_TO_SEND", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    MENU_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MENU_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CONTROLLER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ACTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MENU_LINK = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MENU_ICON = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PAGE_TITLE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PAGE_SUBTITLE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MENU_SHOW = table.Column<bool>(type: "bit", nullable: false),
                    MENU_SORT = table.Column<int>(type: "int", nullable: true),
                    TOPMENU_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.MENU_ID);
                    table.ForeignKey(
                        name: "FK_MENU_MENU_TOPMENU_ID",
                        column: x => x.TOPMENU_ID,
                        principalTable: "MENU",
                        principalColumn: "MENU_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RULE",
                columns: table => new
                {
                    RULE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RULE_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RULE_DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: false),
                    RULE_ACTION_TYPE = table.Column<int>(type: "int", nullable: false),
                    RULE_ACTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RULE_ACTION_DATA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RULE", x => x.RULE_ID);
                });

            migrationBuilder.CreateTable(
                name: "RULE_ACTIONS",
                columns: table => new
                {
                    ACTION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ACTION_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ACTION_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RULE_ACTIONS", x => x.ACTION_ID);
                });

            migrationBuilder.CreateTable(
                name: "RULE_CRITERIA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IS_FOREIGN = table.Column<bool>(type: "bit", nullable: false),
                    FOREIGN_TABLE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FOREIGN_KEY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FOREIGN_VALUE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FOREIGN_WHERE_CLAUSE = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RULE_CRITERIA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SURVEY_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SURVEY_ID = table.Column<int>(type: "int", nullable: false),
                    UNIQUE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SURVEY_HISTORY", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TIMEZONE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UTC_STANDARD_OFFSET = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UTC_DAYLIGHT_OFFSET = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIMEZONE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TITLE",
                columns: table => new
                {
                    TITLE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TITLE", x => x.TITLE_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_GROUP",
                columns: table => new
                {
                    USER_GROUP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_GROUP", x => x.USER_GROUP_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_TYPE",
                columns: table => new
                {
                    USER_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TYPE", x => x.USER_TYPE_ID);
                });

            migrationBuilder.CreateTable(
                name: "WORKING_DAYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKING_DAYS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WORKING_SCHEDULE",
                columns: table => new
                {
                    WORKING_SCHEDULE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    START_TIME = table.Column<TimeSpan>(type: "time", nullable: false),
                    END_TIME = table.Column<TimeSpan>(type: "time", nullable: false),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORKING_SCHEDULE", x => x.WORKING_SCHEDULE_ID);
                });

            migrationBuilder.CreateTable(
                name: "HOLDING",
                columns: table => new
                {
                    HOLDING_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOLDING", x => x.HOLDING_ID);
                    table.ForeignKey(
                        name: "FK_HOLDING_AD_CUSTOMERS_CUSTOMER_ID",
                        column: x => x.CUSTOMER_ID,
                        principalTable: "AD_CUSTOMERS",
                        principalColumn: "CUSTOMER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "REGION",
                columns: table => new
                {
                    REGION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COUNTRY_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGION", x => x.REGION_ID);
                    table.ForeignKey(
                        name: "FK_REGION_COUNTRY_COUNTRY_ID",
                        column: x => x.COUNTRY_ID,
                        principalTable: "COUNTRY",
                        principalColumn: "COUNTRY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MAIN_PROCESS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SHORT_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DOMAIN_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAIN_PROCESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MAIN_PROCESS_DOMAIN_DOMAIN_ID",
                        column: x => x.DOMAIN_ID,
                        principalTable: "DOMAIN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RULE_DETAIL",
                columns: table => new
                {
                    RULE_DETAIL_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRITERIA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VALUE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    REQUIREMENT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CONDITION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RULE_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RULE_DETAIL", x => x.RULE_DETAIL_ID);
                    table.ForeignKey(
                        name: "FK_RULE_DETAIL_RULE_RULE_ID",
                        column: x => x.RULE_ID,
                        principalTable: "RULE",
                        principalColumn: "RULE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIME_MANAGEMENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CALENDAR_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CALENDAR_DAYS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BUSINESS_HOURS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TIMEZONE_ID = table.Column<int>(type: "int", nullable: true),
                    ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIME_MANAGEMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TIME_MANAGEMENT_TIMEZONE_TIMEZONE_ID",
                        column: x => x.TIMEZONE_ID,
                        principalTable: "TIMEZONE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERTYPE_MENU",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERTYPE_MENU", x => new { x.UserTypeId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_USERTYPE_MENU_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MENU",
                        principalColumn: "MENU_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USERTYPE_MENU_USER_TYPE_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "USER_TYPE",
                        principalColumn: "USER_TYPE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    COMPANY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HOLDING_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.COMPANY_ID);
                    table.ForeignKey(
                        name: "FK_COMPANY_HOLDING_HOLDING_ID",
                        column: x => x.HOLDING_ID,
                        principalTable: "HOLDING",
                        principalColumn: "HOLDING_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CITY",
                columns: table => new
                {
                    CITY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    REGION_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITY", x => x.CITY_ID);
                    table.ForeignKey(
                        name: "FK_CITY_REGION_REGION_ID",
                        column: x => x.REGION_ID,
                        principalTable: "REGION",
                        principalColumn: "REGION_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMAIL_TEMPLATE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SUBJECT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BODY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TO_CREATED_USER = table.Column<bool>(type: "bit", nullable: true),
                    TO_ASSIGNED_USER = table.Column<bool>(type: "bit", nullable: true),
                    TO_ASSIGNED_GROUP_USER = table.Column<bool>(type: "bit", nullable: true),
                    TO_USERS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TO_GROUPS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: false),
                    MAIN_PROCESS_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMAIL_TEMPLATE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMAIL_TEMPLATE_MAIN_PROCESS_MAIN_PROCESS_ID",
                        column: x => x.MAIN_PROCESS_ID,
                        principalTable: "MAIN_PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMAIL_TEMPLATE_PARAMETERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARAMETER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMAIL_TEMPLATE_PARAMETERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EMAIL_TEMPLATE_PARAMETERS_MAIN_PROCESS_MAIN_PROCESS_ID",
                        column: x => x.MAIN_PROCESS_ID,
                        principalTable: "MAIN_PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_NUMBERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: false),
                    SYSTEM_CODE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CODE = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LAST_COUNTER = table.Column<int>(type: "int", nullable: false),
                    LAST_ORDER_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_FORMAT_CODE = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_NUMBERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_NUMBERS_MAIN_PROCESS_MAIN_PROCESS_ID",
                        column: x => x.MAIN_PROCESS_ID,
                        principalTable: "MAIN_PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER_TYPE",
                columns: table => new
                {
                    PARAMETER_TYPE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TYPE_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETER_TYPE", x => x.PARAMETER_TYPE_ID);
                    table.ForeignKey(
                        name: "FK_PARAMETER_TYPE_MAIN_PROCESS_MAIN_PROCESS_ID",
                        column: x => x.MAIN_PROCESS_ID,
                        principalTable: "MAIN_PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TIME_MANAGEMENT_OFFDAYS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YEAR = table.Column<int>(type: "int", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OFF_DAY = table.Column<int>(type: "int", nullable: false),
                    TIME_MANAGEMENT_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIME_MANAGEMENT_OFFDAYS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TIME_MANAGEMENT_OFFDAYS_TIME_MANAGEMENT_TIME_MANAGEMENT_ID",
                        column: x => x.TIME_MANAGEMENT_ID,
                        principalTable: "TIME_MANAGEMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENT",
                columns: table => new
                {
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    COMPANY_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENT", x => x.DEPARTMENT_ID);
                    table.ForeignKey(
                        name: "FK_DEPARTMENT_COMPANY_COMPANY_ID",
                        column: x => x.COMPANY_ID,
                        principalTable: "COMPANY",
                        principalColumn: "COMPANY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LOCATION",
                columns: table => new
                {
                    LOCATION_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CITY_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOCATION", x => x.LOCATION_ID);
                    table.ForeignKey(
                        name: "FK_LOCATION_CITY_CITY_ID",
                        column: x => x.CITY_ID,
                        principalTable: "CITY",
                        principalColumn: "CITY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MAIN_DATA_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PRIORITY_ORDER = table.Column<int>(type: "int", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    PARAMETER_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_PARAMETER_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARAMETER_MAIN_PROCESS_MAIN_PROCESS_ID",
                        column: x => x.MAIN_PROCESS_ID,
                        principalTable: "MAIN_PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PARAMETER_PARAMETER_PARENT_PARAMETER_ID",
                        column: x => x.PARENT_PARAMETER_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PARAMETER_PARAMETER_TYPE_PARAMETER_TYPE_ID",
                        column: x => x.PARAMETER_TYPE_ID,
                        principalTable: "PARAMETER_TYPE",
                        principalColumn: "PARAMETER_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PASSWORD = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SURNAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ISLDAP = table.Column<bool>(type: "bit", nullable: true),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: true),
                    TITLE_ID = table.Column<int>(type: "int", nullable: true),
                    USER_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    LOCATION_ID = table.Column<int>(type: "int", nullable: true),
                    MANAGER_ID = table.Column<int>(type: "int", nullable: true),
                    USER_GROUP_ID = table.Column<int>(type: "int", nullable: true),
                    IMAGE_PATH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    USER_ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_USER_DEPARTMENT_DEPARTMENT_ID",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "DEPARTMENT",
                        principalColumn: "DEPARTMENT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_LOCATION_LOCATION_ID",
                        column: x => x.LOCATION_ID,
                        principalTable: "LOCATION",
                        principalColumn: "LOCATION_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_TITLE_TITLE_ID",
                        column: x => x.TITLE_ID,
                        principalTable: "TITLE",
                        principalColumn: "TITLE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_USER_GROUP_USER_GROUP_ID",
                        column: x => x.USER_GROUP_ID,
                        principalTable: "USER_GROUP",
                        principalColumn: "USER_GROUP_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_USER_TYPE_USER_TYPE_ID",
                        column: x => x.USER_TYPE_ID,
                        principalTable: "USER_TYPE",
                        principalColumn: "USER_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KNOWLEDGE_SETTINGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WHICH_STATUS_IN_VISIBLE = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNOWLEDGE_SETTINGS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KNOWLEDGE_SETTINGS_PARAMETER_WHICH_STATUS_IN_VISIBLE",
                        column: x => x.WHICH_STATUS_IN_VISIBLE,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: false),
                    IMPORTANCE_LEVEL_ID = table.Column<int>(type: "int", nullable: false),
                    WORKING_SCHEDULE_ID = table.Column<int>(type: "int", nullable: false),
                    EFFORT_MINUTE = table.Column<int>(type: "int", nullable: false),
                    EFFORT_HOUR = table.Column<int>(type: "int", nullable: false),
                    EFFORT_DAY = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SLA_MAIN_PROCESS_MAIN_PROCESS_ID",
                        column: x => x.MAIN_PROCESS_ID,
                        principalTable: "MAIN_PROCESS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SLA_PARAMETER_IMPORTANCE_LEVEL_ID",
                        column: x => x.IMPORTANCE_LEVEL_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SLA_WORKING_SCHEDULE_WORKING_SCHEDULE_ID",
                        column: x => x.WORKING_SCHEDULE_ID,
                        principalTable: "WORKING_SCHEDULE",
                        principalColumn: "WORKING_SCHEDULE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SURVEY",
                columns: table => new
                {
                    SURVEY_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SURVEY_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SURVEY_SEND_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    MAIN_PROCESS_ID = table.Column<int>(type: "int", nullable: true),
                    SURVEY_PARAMETER_ID = table.Column<int>(type: "int", nullable: true),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EXECUTION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TO_USERS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TO_GROUPS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TO_CREATED_USER = table.Column<bool>(type: "bit", nullable: true),
                    TO_ASSIGNED_USER = table.Column<bool>(type: "bit", nullable: true),
                    TO_ASSIGNED_GROUP_USER = table.Column<bool>(type: "bit", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SURVEY", x => x.SURVEY_ID);
                    table.ForeignKey(
                        name: "FK_SURVEY_PARAMETER_SURVEY_PARAMETER_ID",
                        column: x => x.SURVEY_PARAMETER_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GROUP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUP_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GROUP_MANAGER_ID = table.Column<int>(type: "int", nullable: false),
                    GROUP_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    BUSINESS_HOURS = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    GROUP_ASSIGNTYPE_ID = table.Column<int>(type: "int", nullable: false),
                    GROUP_DESCRIPTION = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    GROUP_ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GROUP_GROUP_TYPE_GROUP_TYPE_ID",
                        column: x => x.GROUP_TYPE_ID,
                        principalTable: "GROUP_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GROUP_USER_GROUP_MANAGER_ID",
                        column: x => x.GROUP_MANAGER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LEAVE",
                columns: table => new
                {
                    LEAVE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LEAVE_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    TOTAL_DAY = table.Column<int>(type: "int", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LEAVE", x => x.LEAVE_ID);
                    table.ForeignKey(
                        name: "FK_LEAVE_LEAVE_TYPE_LEAVE_TYPE_ID",
                        column: x => x.LEAVE_TYPE_ID,
                        principalTable: "LEAVE_TYPE",
                        principalColumn: "LEAVE_TYPE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LEAVE_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PASSWORD_CHANGE_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNIQUE_IDENTIFIER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CHANGE_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PASSWORD_CHANGE_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PASSWORD_CHANGE_HISTORY_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SERVICECATALOG",
                columns: table => new
                {
                    SERVICE_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SERVICE_NAME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SERVICE_PARAMETER_ID = table.Column<int>(type: "int", nullable: false),
                    SERVICE_LEVEL = table.Column<int>(type: "int", nullable: false),
                    OPERATIONAL_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    SERVICE_MANAGER_IT_ID = table.Column<int>(type: "int", nullable: false),
                    SERVICE_MANAGER_BUSINESS_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SERVICECATALOG", x => x.SERVICE_ID);
                    table.ForeignKey(
                        name: "FK_SERVICECATALOG_PARAMETER_OPERATIONAL_STATUS_ID",
                        column: x => x.OPERATIONAL_STATUS_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SERVICECATALOG_PARAMETER_SERVICE_PARAMETER_ID",
                        column: x => x.SERVICE_PARAMETER_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SERVICECATALOG_USER_SERVICE_MANAGER_BUSINESS_ID",
                        column: x => x.SERVICE_MANAGER_BUSINESS_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SERVICECATALOG_USER_SERVICE_MANAGER_IT_ID",
                        column: x => x.SERVICE_MANAGER_IT_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLA_AREA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLA_ID = table.Column<int>(type: "int", nullable: false),
                    SLA_AREA_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    CUSTOMER_ID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SERVICE_ID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ASSET_ID = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLA_AREA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SLA_AREA_SLA_SLA_ID",
                        column: x => x.SLA_ID,
                        principalTable: "SLA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLA_EVENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLA_ID = table.Column<int>(type: "int", nullable: false),
                    EVENT_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLA_EVENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SLA_EVENTS_PARAMETER_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SLA_EVENTS_SLA_SLA_ID",
                        column: x => x.SLA_ID,
                        principalTable: "SLA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SURVEY_QUESTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QUESTION_TEXT = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    SURVEY_ANSWER_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    EVALUATION_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EVALUATION_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EVALUATION_3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EVALUATION_4 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EVALUATION_5 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BINARY_OPTION_1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BINARY_OPTION_2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SURVEY_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SURVEY_QUESTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SURVEY_QUESTION_SURVEY_SURVEY_ID",
                        column: x => x.SURVEY_ID,
                        principalTable: "SURVEY",
                        principalColumn: "SURVEY_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GROUP_EXPERT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GROUP_ID = table.Column<int>(type: "int", nullable: false),
                    EXPERT_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXPERT_NAME_ID = table.Column<int>(type: "int", nullable: false),
                    EXPERT_EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GROUP_EXPERT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GROUP_EXPERT_GROUP_GROUP_ID",
                        column: x => x.GROUP_ID,
                        principalTable: "GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INCIDENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SUBJECT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    REPORTING_USER_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_PRIORITY_ID = table.Column<int>(type: "int", nullable: false),
                    INCIDENT_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    SERVICE_CATALOG_ID = table.Column<int>(type: "int", nullable: true),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_URGENCY_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_IMPACT_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    ASSIGNED_GROUP_ID = table.Column<int>(type: "int", nullable: true),
                    ASSIGNED_USER_ID = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCIDENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INCIDENT_GROUP_ASSIGNED_GROUP_ID",
                        column: x => x.ASSIGNED_GROUP_ID,
                        principalTable: "GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_INCIDENT_IMPACT_ID",
                        column: x => x.INCIDENT_IMPACT_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_INCIDENT_PRIORITY_ID",
                        column: x => x.INCIDENT_PRIORITY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_INCIDENT_SOURCE_ID",
                        column: x => x.INCIDENT_SOURCE_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_INCIDENT_STATUS_ID",
                        column: x => x.INCIDENT_STATUS_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_INCIDENT_TYPE_ID",
                        column: x => x.INCIDENT_TYPE_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_INCIDENT_URGENCY_ID",
                        column: x => x.INCIDENT_URGENCY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_PARAMETER_SUB_CATEGORY_ID",
                        column: x => x.SUB_CATEGORY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_SERVICECATALOG_SERVICE_CATALOG_ID",
                        column: x => x.SERVICE_CATALOG_ID,
                        principalTable: "SERVICECATALOG",
                        principalColumn: "SERVICE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_USER_ASSIGNED_USER_ID",
                        column: x => x.ASSIGNED_USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_USER_REPORTING_USER_ID",
                        column: x => x.REPORTING_USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KNOWLEDGE_MANAGEMENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KNOWLEDGE_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    KNOWLEDGE_ISACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    SUBJECT = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    KNOWLEDGE_SERVICE_ID = table.Column<int>(type: "int", nullable: false),
                    KNOWLEDGE_CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    KNOWLEDGE_STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    KNOWLEDGE_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNOWLEDGE_MANAGEMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KNOWLEDGE_MANAGEMENT_PARAMETER_KNOWLEDGE_CATEGORY_ID",
                        column: x => x.KNOWLEDGE_CATEGORY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KNOWLEDGE_MANAGEMENT_PARAMETER_KNOWLEDGE_STATUS_ID",
                        column: x => x.KNOWLEDGE_STATUS_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KNOWLEDGE_MANAGEMENT_SERVICECATALOG_KNOWLEDGE_SERVICE_ID",
                        column: x => x.KNOWLEDGE_SERVICE_ID,
                        principalTable: "SERVICECATALOG",
                        principalColumn: "SERVICE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SURVEY_QUESTION_ANSWER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SURVEY_QUESTION_ID = table.Column<int>(type: "int", nullable: false),
                    SURVEY_HISTORY_ID = table.Column<int>(type: "int", nullable: false),
                    ANSWER = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SURVEY_QUESTION_ANSWER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SURVEY_QUESTION_ANSWER_SURVEY_HISTORY_SURVEY_HISTORY_ID",
                        column: x => x.SURVEY_HISTORY_ID,
                        principalTable: "SURVEY_HISTORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SURVEY_QUESTION_ANSWER_SURVEY_QUESTION_SURVEY_QUESTION_ID",
                        column: x => x.SURVEY_QUESTION_ID,
                        principalTable: "SURVEY_QUESTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INCIDENT_FILES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILE_PATH = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    INCIDENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCIDENT_FILES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INCIDENT_FILES_INCIDENT_INCIDENT_ID",
                        column: x => x.INCIDENT_ID,
                        principalTable: "INCIDENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INCIDENT_HISTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SUBJECT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    REPORTING_USER_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_PRIORITY_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_STATUS_ID = table.Column<int>(type: "int", nullable: true),
                    SERVICE_CATALOG_ID = table.Column<int>(type: "int", nullable: true),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    SUB_CATEGORY_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_URGENCY_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_IMPACT_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_TYPE_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_SOURCE_ID = table.Column<int>(type: "int", nullable: true),
                    ASSIGNED_GROUP_ID = table.Column<int>(type: "int", nullable: true),
                    ASSIGNED_USER_ID = table.Column<int>(type: "int", nullable: true),
                    INCIDENT_ID = table.Column<int>(type: "int", nullable: false),
                    VISIBLE_TO_USER = table.Column<bool>(type: "bit", nullable: false),
                    VISIBLE_TO_OPERATOR = table.Column<bool>(type: "bit", nullable: false),
                    EFFORT_DAY = table.Column<int>(type: "int", nullable: true),
                    EFFORT_HOUR = table.Column<int>(type: "int", nullable: true),
                    EFFORT_MINUTE = table.Column<int>(type: "int", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCIDENT_HISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_GROUP_ASSIGNED_GROUP_ID",
                        column: x => x.ASSIGNED_GROUP_ID,
                        principalTable: "GROUP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_INCIDENT_INCIDENT_ID",
                        column: x => x.INCIDENT_ID,
                        principalTable: "INCIDENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_INCIDENT_IMPACT_ID",
                        column: x => x.INCIDENT_IMPACT_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_INCIDENT_PRIORITY_ID",
                        column: x => x.INCIDENT_PRIORITY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_INCIDENT_SOURCE_ID",
                        column: x => x.INCIDENT_SOURCE_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_INCIDENT_STATUS_ID",
                        column: x => x.INCIDENT_STATUS_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_INCIDENT_TYPE_ID",
                        column: x => x.INCIDENT_TYPE_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_INCIDENT_URGENCY_ID",
                        column: x => x.INCIDENT_URGENCY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_PARAMETER_SUB_CATEGORY_ID",
                        column: x => x.SUB_CATEGORY_ID,
                        principalTable: "PARAMETER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_SERVICECATALOG_SERVICE_CATALOG_ID",
                        column: x => x.SERVICE_CATALOG_ID,
                        principalTable: "SERVICECATALOG",
                        principalColumn: "SERVICE_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_USER_ASSIGNED_USER_ID",
                        column: x => x.ASSIGNED_USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_INCIDENT_HISTORY_USER_REPORTING_USER_ID",
                        column: x => x.REPORTING_USER_ID,
                        principalTable: "USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "INCIDENT_RESOLUTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RESOLVED_CODE = table.Column<int>(type: "int", nullable: false),
                    RESOLVED_DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IS_APPROVED = table.Column<bool>(type: "bit", nullable: false),
                    RESOLVED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    INCIDENT_ID = table.Column<int>(type: "int", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INCIDENT_RESOLUTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INCIDENT_RESOLUTION_INCIDENT_INCIDENT_ID",
                        column: x => x.INCIDENT_ID,
                        principalTable: "INCIDENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KNOWLEDGE_FILES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FILE_PATH = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    KNOWLEDGE_ID = table.Column<int>(type: "int", nullable: false),
                    FILE_NAME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_DELETED = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KNOWLEDGE_FILES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KNOWLEDGE_FILES_KNOWLEDGE_MANAGEMENT_KNOWLEDGE_ID",
                        column: x => x.KNOWLEDGE_ID,
                        principalTable: "KNOWLEDGE_MANAGEMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CITY_REGION_ID",
                table: "CITY",
                column: "REGION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_HOLDING_ID",
                table: "COMPANY",
                column: "HOLDING_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_COMPANY_ID",
                table: "DEPARTMENT",
                column: "COMPANY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_TEMPLATE_MAIN_PROCESS_ID",
                table: "EMAIL_TEMPLATE",
                column: "MAIN_PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_TEMPLATE_PARAMETERS_MAIN_PROCESS_ID",
                table: "EMAIL_TEMPLATE_PARAMETERS",
                column: "MAIN_PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_GROUP_MANAGER_ID",
                table: "GROUP",
                column: "GROUP_MANAGER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_GROUP_TYPE_ID",
                table: "GROUP",
                column: "GROUP_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_EXPERT_GROUP_ID",
                table: "GROUP_EXPERT",
                column: "GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HOLDING_CUSTOMER_ID",
                table: "HOLDING",
                column: "CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_ASSIGNED_GROUP_ID",
                table: "INCIDENT",
                column: "ASSIGNED_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_ASSIGNED_USER_ID",
                table: "INCIDENT",
                column: "ASSIGNED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_CATEGORY_ID",
                table: "INCIDENT",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_INCIDENT_IMPACT_ID",
                table: "INCIDENT",
                column: "INCIDENT_IMPACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_INCIDENT_PRIORITY_ID",
                table: "INCIDENT",
                column: "INCIDENT_PRIORITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_INCIDENT_SOURCE_ID",
                table: "INCIDENT",
                column: "INCIDENT_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_INCIDENT_STATUS_ID",
                table: "INCIDENT",
                column: "INCIDENT_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_INCIDENT_TYPE_ID",
                table: "INCIDENT",
                column: "INCIDENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_INCIDENT_URGENCY_ID",
                table: "INCIDENT",
                column: "INCIDENT_URGENCY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_REPORTING_USER_ID",
                table: "INCIDENT",
                column: "REPORTING_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_SERVICE_CATALOG_ID",
                table: "INCIDENT",
                column: "SERVICE_CATALOG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_SUB_CATEGORY_ID",
                table: "INCIDENT",
                column: "SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_FILES_INCIDENT_ID",
                table: "INCIDENT_FILES",
                column: "INCIDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_ASSIGNED_GROUP_ID",
                table: "INCIDENT_HISTORY",
                column: "ASSIGNED_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_ASSIGNED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "ASSIGNED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_CATEGORY_ID",
                table: "INCIDENT_HISTORY",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_IMPACT_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_IMPACT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_PRIORITY_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_PRIORITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_SOURCE_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_SOURCE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_STATUS_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_TYPE_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_INCIDENT_URGENCY_ID",
                table: "INCIDENT_HISTORY",
                column: "INCIDENT_URGENCY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_REPORTING_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "REPORTING_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_SERVICE_CATALOG_ID",
                table: "INCIDENT_HISTORY",
                column: "SERVICE_CATALOG_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_SUB_CATEGORY_ID",
                table: "INCIDENT_HISTORY",
                column: "SUB_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_RESOLUTION_INCIDENT_ID",
                table: "INCIDENT_RESOLUTION",
                column: "INCIDENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_FILES_KNOWLEDGE_ID",
                table: "KNOWLEDGE_FILES",
                column: "KNOWLEDGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_KNOWLEDGE_CATEGORY_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "KNOWLEDGE_CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_KNOWLEDGE_SERVICE_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "KNOWLEDGE_SERVICE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_KNOWLEDGE_STATUS_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "KNOWLEDGE_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_SETTINGS_WHICH_STATUS_IN_VISIBLE",
                table: "KNOWLEDGE_SETTINGS",
                column: "WHICH_STATUS_IN_VISIBLE");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_LEAVE_TYPE_ID",
                table: "LEAVE",
                column: "LEAVE_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_USER_ID",
                table: "LEAVE",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_CITY_ID",
                table: "LOCATION",
                column: "CITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAIN_PROCESS_DOMAIN_ID",
                table: "MAIN_PROCESS",
                column: "DOMAIN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_TOPMENU_ID",
                table: "MENU",
                column: "TOPMENU_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_NUMBERS_MAIN_PROCESS_ID",
                table: "ORDER_NUMBERS",
                column: "MAIN_PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_MAIN_PROCESS_ID",
                table: "PARAMETER",
                column: "MAIN_PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_PARAMETER_TYPE_ID",
                table: "PARAMETER",
                column: "PARAMETER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_PARENT_PARAMETER_ID",
                table: "PARAMETER",
                column: "PARENT_PARAMETER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_TYPE_MAIN_PROCESS_ID",
                table: "PARAMETER_TYPE",
                column: "MAIN_PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PASSWORD_CHANGE_HISTORY_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REGION_COUNTRY_ID",
                table: "REGION",
                column: "COUNTRY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RULE_DETAIL_RULE_ID",
                table: "RULE_DETAIL",
                column: "RULE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_OPERATIONAL_STATUS_ID",
                table: "SERVICECATALOG",
                column: "OPERATIONAL_STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_SERVICE_MANAGER_BUSINESS_ID",
                table: "SERVICECATALOG",
                column: "SERVICE_MANAGER_BUSINESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_SERVICE_MANAGER_IT_ID",
                table: "SERVICECATALOG",
                column: "SERVICE_MANAGER_IT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_SERVICE_PARAMETER_ID",
                table: "SERVICECATALOG",
                column: "SERVICE_PARAMETER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_IMPORTANCE_LEVEL_ID",
                table: "SLA",
                column: "IMPORTANCE_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_MAIN_PROCESS_ID",
                table: "SLA",
                column: "MAIN_PROCESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_WORKING_SCHEDULE_ID",
                table: "SLA",
                column: "WORKING_SCHEDULE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_AREA_SLA_ID",
                table: "SLA_AREA",
                column: "SLA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_EVENTS_SLA_ID",
                table: "SLA_EVENTS",
                column: "SLA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_EVENTS_STATUS_ID",
                table: "SLA_EVENTS",
                column: "STATUS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_SURVEY_PARAMETER_ID",
                table: "SURVEY",
                column: "SURVEY_PARAMETER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_QUESTION_SURVEY_ID",
                table: "SURVEY_QUESTION",
                column: "SURVEY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_QUESTION_ANSWER_SURVEY_HISTORY_ID",
                table: "SURVEY_QUESTION_ANSWER",
                column: "SURVEY_HISTORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_QUESTION_ANSWER_SURVEY_QUESTION_ID",
                table: "SURVEY_QUESTION_ANSWER",
                column: "SURVEY_QUESTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TIME_MANAGEMENT_TIMEZONE_ID",
                table: "TIME_MANAGEMENT",
                column: "TIMEZONE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TIME_MANAGEMENT_OFFDAYS_TIME_MANAGEMENT_ID",
                table: "TIME_MANAGEMENT_OFFDAYS",
                column: "TIME_MANAGEMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_DEPARTMENT_ID",
                table: "USER",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_LOCATION_ID",
                table: "USER",
                column: "LOCATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_TITLE_ID",
                table: "USER",
                column: "TITLE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_USER_GROUP_ID",
                table: "USER",
                column: "USER_GROUP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_USER_TYPE_ID",
                table: "USER",
                column: "USER_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERTYPE_MENU_MenuId",
                table: "USERTYPE_MENU",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMAIL_TEMPLATE");

            migrationBuilder.DropTable(
                name: "EMAIL_TEMPLATE_PARAMETERS");

            migrationBuilder.DropTable(
                name: "GENERAL_SETTINGS");

            migrationBuilder.DropTable(
                name: "GROUP_EXPERT");

            migrationBuilder.DropTable(
                name: "INCIDENT_FILES");

            migrationBuilder.DropTable(
                name: "INCIDENT_HISTORY");

            migrationBuilder.DropTable(
                name: "INCIDENT_RESOLUTION");

            migrationBuilder.DropTable(
                name: "INCIDENT_TYPE");

            migrationBuilder.DropTable(
                name: "KNOWLEDGE_FILES");

            migrationBuilder.DropTable(
                name: "KNOWLEDGE_SETTINGS");

            migrationBuilder.DropTable(
                name: "LDAP_INFO");

            migrationBuilder.DropTable(
                name: "LEAVE");

            migrationBuilder.DropTable(
                name: "LOGGER_REQUEST");

            migrationBuilder.DropTable(
                name: "LOGGER_RESPONSE");

            migrationBuilder.DropTable(
                name: "MAIL_SERVER_SETUP");

            migrationBuilder.DropTable(
                name: "MAIL_TO_SEND");

            migrationBuilder.DropTable(
                name: "ORDER_NUMBERS");

            migrationBuilder.DropTable(
                name: "PASSWORD_CHANGE_HISTORY");

            migrationBuilder.DropTable(
                name: "RULE_ACTIONS");

            migrationBuilder.DropTable(
                name: "RULE_CRITERIA");

            migrationBuilder.DropTable(
                name: "RULE_DETAIL");

            migrationBuilder.DropTable(
                name: "SLA_AREA");

            migrationBuilder.DropTable(
                name: "SLA_EVENTS");

            migrationBuilder.DropTable(
                name: "SURVEY_QUESTION_ANSWER");

            migrationBuilder.DropTable(
                name: "TIME_MANAGEMENT_OFFDAYS");

            migrationBuilder.DropTable(
                name: "USERTYPE_MENU");

            migrationBuilder.DropTable(
                name: "WORKING_DAYS");

            migrationBuilder.DropTable(
                name: "INCIDENT");

            migrationBuilder.DropTable(
                name: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropTable(
                name: "LEAVE_TYPE");

            migrationBuilder.DropTable(
                name: "RULE");

            migrationBuilder.DropTable(
                name: "SLA");

            migrationBuilder.DropTable(
                name: "SURVEY_HISTORY");

            migrationBuilder.DropTable(
                name: "SURVEY_QUESTION");

            migrationBuilder.DropTable(
                name: "TIME_MANAGEMENT");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "GROUP");

            migrationBuilder.DropTable(
                name: "SERVICECATALOG");

            migrationBuilder.DropTable(
                name: "WORKING_SCHEDULE");

            migrationBuilder.DropTable(
                name: "SURVEY");

            migrationBuilder.DropTable(
                name: "TIMEZONE");

            migrationBuilder.DropTable(
                name: "GROUP_TYPE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "PARAMETER");

            migrationBuilder.DropTable(
                name: "DEPARTMENT");

            migrationBuilder.DropTable(
                name: "LOCATION");

            migrationBuilder.DropTable(
                name: "TITLE");

            migrationBuilder.DropTable(
                name: "USER_GROUP");

            migrationBuilder.DropTable(
                name: "USER_TYPE");

            migrationBuilder.DropTable(
                name: "PARAMETER_TYPE");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "CITY");

            migrationBuilder.DropTable(
                name: "MAIN_PROCESS");

            migrationBuilder.DropTable(
                name: "HOLDING");

            migrationBuilder.DropTable(
                name: "REGION");

            migrationBuilder.DropTable(
                name: "DOMAIN");

            migrationBuilder.DropTable(
                name: "AD_CUSTOMERS");

            migrationBuilder.DropTable(
                name: "COUNTRY");
        }
    }
}
