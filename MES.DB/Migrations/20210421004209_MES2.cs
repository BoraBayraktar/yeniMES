using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "WORKING_SCHEDULE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "WORKING_SCHEDULE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "WORKING_DAYS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "WORKING_DAYS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "USERTYPE_MENU",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "USERTYPE_MENU",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "USER_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "USER_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "USER_GROUP",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "USER_GROUP",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "USER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "USER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "TITLE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "TITLE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "TIME_MANAGEMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "TIME_MANAGEMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SURVEY_QUESTION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SURVEY_QUESTION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SURVEY_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SURVEY_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SURVEY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SURVEY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SLA_EVENTS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SLA_EVENTS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SLA_AREA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SLA_AREA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SLA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SLA",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "SERVICECATALOG",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "SERVICECATALOG",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "RULE_DETAIL",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "RULE_DETAIL",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "RULE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "RULE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "REGION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "REGION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "PARAMETER_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "PARAMETER_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "PARAMETER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "PARAMETER",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "ORDER_NUMBERS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "ORDER_NUMBERS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "MAIN_PROCESS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "MAIN_PROCESS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "MAIL_TO_SEND",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "MAIL_TO_SEND",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "MAIL_SERVER_SETUP",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "MAIL_SERVER_SETUP",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "LOCATION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "LOCATION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "LEAVE_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "LEAVE_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "LEAVE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "LEAVE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "LDAP_INFO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "LDAP_INFO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "INCIDENT_RESOLUTION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "INCIDENT_RESOLUTION",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "INCIDENT_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "INCIDENT_HISTORY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "INCIDENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "INCIDENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "HOLDING",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "HOLDING",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "GROUP_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "GROUP_TYPE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "GROUP_EXPERT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "GROUP_EXPERT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "GROUP",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "GROUP",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "EMAIL_TEMPLATE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "EMAIL_TEMPLATE",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "DOMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "DOMAIN",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "DEPARTMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "DEPARTMENT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "COUNTRY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "COUNTRY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "COMPANY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "COMPANY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CREATED_USER_ID",
                table: "CITY",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UPDATED_USER_ID",
                table: "CITY",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "WORKING_SCHEDULE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "WORKING_SCHEDULE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "WORKING_DAYS");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "WORKING_DAYS");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "USERTYPE_MENU");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "USERTYPE_MENU");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "USER_TYPE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "USER_TYPE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "USER_GROUP");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "USER_GROUP");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "USER");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "TITLE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "TITLE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "TIME_MANAGEMENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "TIME_MANAGEMENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SURVEY_QUESTION");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SURVEY_QUESTION");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SURVEY_HISTORY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SURVEY_HISTORY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SURVEY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SURVEY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SLA_EVENTS");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SLA_EVENTS");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SLA_AREA");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SLA_AREA");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SLA");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SLA");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "RULE_DETAIL");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "RULE_DETAIL");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "RULE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "RULE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "REGION");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "REGION");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "PARAMETER_TYPE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "PARAMETER_TYPE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "PARAMETER");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "PARAMETER");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "ORDER_NUMBERS");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "ORDER_NUMBERS");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "MAIN_PROCESS");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "MAIN_PROCESS");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "MAIL_TO_SEND");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "MAIL_TO_SEND");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "MAIL_SERVER_SETUP");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "MAIL_SERVER_SETUP");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "LOCATION");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "LOCATION");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "LEAVE_TYPE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "LEAVE_TYPE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "LEAVE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "LEAVE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "LDAP_INFO");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "LDAP_INFO");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "INCIDENT_RESOLUTION");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "INCIDENT_RESOLUTION");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "HOLDING");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "HOLDING");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "GROUP_TYPE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "GROUP_TYPE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "GROUP_EXPERT");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "GROUP_EXPERT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "GROUP");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "GROUP");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "EMAIL_TEMPLATE");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "EMAIL_TEMPLATE");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "DOMAIN");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "DOMAIN");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "DEPARTMENT");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "DEPARTMENT");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "COUNTRY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "COUNTRY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "COMPANY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "COMPANY");

            migrationBuilder.DropColumn(
                name: "CREATED_USER_ID",
                table: "CITY");

            migrationBuilder.DropColumn(
                name: "UPDATED_USER_ID",
                table: "CITY");
        }
    }
}
