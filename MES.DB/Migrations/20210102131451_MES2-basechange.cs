using Microsoft.EntityFrameworkCore.Migrations;

namespace MES.DB.Migrations
{
    public partial class MES2basechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CITY_USER_CREATED_USER_ID",
                table: "CITY");

            migrationBuilder.DropForeignKey(
                name: "FK_COMPANY_USER_CREATED_USER_ID",
                table: "COMPANY");

            migrationBuilder.DropForeignKey(
                name: "FK_COUNTRY_USER_CREATED_USER_ID",
                table: "COUNTRY");

            migrationBuilder.DropForeignKey(
                name: "FK_DEPARTMENT_USER_CREATED_USER_ID",
                table: "DEPARTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_DOMAIN_USER_CREATED_USER_ID",
                table: "DOMAIN");

            migrationBuilder.DropForeignKey(
                name: "FK_EMAIL_TEMPLATE_USER_CREATED_USER_ID",
                table: "EMAIL_TEMPLATE");

            migrationBuilder.DropForeignKey(
                name: "FK_GROUP_USER_CREATED_USER_ID",
                table: "GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_GROUP_EXPERT_USER_CREATED_USER_ID",
                table: "GROUP_EXPERT");

            migrationBuilder.DropForeignKey(
                name: "FK_GROUP_TYPE_USER_CREATED_USER_ID",
                table: "GROUP_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_HOLDING_USER_CREATED_USER_ID",
                table: "HOLDING");

            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_USER_CREATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_HISTORY_USER_CREATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_INCIDENT_RESOLUTION_USER_CREATED_USER_ID",
                table: "INCIDENT_RESOLUTION");

            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_FILES_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_MANAGEMENT_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_KNOWLEDGE_SETTINGS_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS");

            migrationBuilder.DropForeignKey(
                name: "FK_LDAP_INFO_USER_CREATED_USER_ID",
                table: "LDAP_INFO");

            migrationBuilder.DropForeignKey(
                name: "FK_LEAVE_USER_CREATED_USER_ID",
                table: "LEAVE");

            migrationBuilder.DropForeignKey(
                name: "FK_LEAVE_TYPE_USER_CREATED_USER_ID",
                table: "LEAVE_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_LOCATION_USER_CREATED_USER_ID",
                table: "LOCATION");

            migrationBuilder.DropForeignKey(
                name: "FK_MAIL_SERVER_SETUP_USER_CREATED_USER_ID",
                table: "MAIL_SERVER_SETUP");

            migrationBuilder.DropForeignKey(
                name: "FK_MAIL_TO_SEND_USER_CREATED_USER_ID",
                table: "MAIL_TO_SEND");

            migrationBuilder.DropForeignKey(
                name: "FK_MAIN_PROCESS_USER_CREATED_USER_ID",
                table: "MAIN_PROCESS");

            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_NUMBERS_USER_CREATED_USER_ID",
                table: "ORDER_NUMBERS");

            migrationBuilder.DropForeignKey(
                name: "FK_PARAMETER_USER_CREATED_USER_ID",
                table: "PARAMETER");

            migrationBuilder.DropForeignKey(
                name: "FK_PARAMETER_TYPE_USER_CREATED_USER_ID",
                table: "PARAMETER_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_PASSWORD_CHANGE_HISTORY_USER_CREATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_REGION_USER_CREATED_USER_ID",
                table: "REGION");

            migrationBuilder.DropForeignKey(
                name: "FK_RULE_USER_CREATED_USER_ID",
                table: "RULE");

            migrationBuilder.DropForeignKey(
                name: "FK_RULE_DETAIL_USER_CREATED_USER_ID",
                table: "RULE_DETAIL");

            migrationBuilder.DropForeignKey(
                name: "FK_SERVICECATALOG_USER_CREATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropForeignKey(
                name: "FK_SLA_USER_CREATED_USER_ID",
                table: "SLA");

            migrationBuilder.DropForeignKey(
                name: "FK_SLA_AREA_USER_CREATED_USER_ID",
                table: "SLA_AREA");

            migrationBuilder.DropForeignKey(
                name: "FK_SLA_EVENTS_USER_CREATED_USER_ID",
                table: "SLA_EVENTS");

            migrationBuilder.DropForeignKey(
                name: "FK_SURVEY_USER_CREATED_USER_ID",
                table: "SURVEY");

            migrationBuilder.DropForeignKey(
                name: "FK_SURVEY_HISTORY_USER_CREATED_USER_ID",
                table: "SURVEY_HISTORY");

            migrationBuilder.DropForeignKey(
                name: "FK_SURVEY_QUESTION_USER_CREATED_USER_ID",
                table: "SURVEY_QUESTION");

            migrationBuilder.DropForeignKey(
                name: "FK_SURVEY_QUESTION_ANSWER_USER_CREATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER");

            migrationBuilder.DropForeignKey(
                name: "FK_TIME_MANAGEMENT_USER_CREATED_USER_ID",
                table: "TIME_MANAGEMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TIME_MANAGEMENT_OFFDAYS_USER_CREATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS");

            migrationBuilder.DropForeignKey(
                name: "FK_TITLE_USER_CREATED_USER_ID",
                table: "TITLE");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_USER_CREATED_USER_ID",
                table: "USER");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_GROUP_USER_CREATED_USER_ID",
                table: "USER_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_USER_TYPE_USER_CREATED_USER_ID",
                table: "USER_TYPE");

            migrationBuilder.DropForeignKey(
                name: "FK_USERTYPE_MENU_USER_CREATED_USER_ID",
                table: "USERTYPE_MENU");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKING_DAYS_USER_CREATED_USER_ID",
                table: "WORKING_DAYS");

            migrationBuilder.DropForeignKey(
                name: "FK_WORKING_SCHEDULE_USER_CREATED_USER_ID",
                table: "WORKING_SCHEDULE");

            migrationBuilder.DropIndex(
                name: "IX_WORKING_SCHEDULE_CREATED_USER_ID",
                table: "WORKING_SCHEDULE");

            migrationBuilder.DropIndex(
                name: "IX_WORKING_DAYS_CREATED_USER_ID",
                table: "WORKING_DAYS");

            migrationBuilder.DropIndex(
                name: "IX_USERTYPE_MENU_CREATED_USER_ID",
                table: "USERTYPE_MENU");

            migrationBuilder.DropIndex(
                name: "IX_USER_TYPE_CREATED_USER_ID",
                table: "USER_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_USER_GROUP_CREATED_USER_ID",
                table: "USER_GROUP");

            migrationBuilder.DropIndex(
                name: "IX_USER_CREATED_USER_ID",
                table: "USER");

            migrationBuilder.DropIndex(
                name: "IX_TITLE_CREATED_USER_ID",
                table: "TITLE");

            migrationBuilder.DropIndex(
                name: "IX_TIME_MANAGEMENT_OFFDAYS_CREATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS");

            migrationBuilder.DropIndex(
                name: "IX_TIME_MANAGEMENT_CREATED_USER_ID",
                table: "TIME_MANAGEMENT");

            migrationBuilder.DropIndex(
                name: "IX_SURVEY_QUESTION_ANSWER_CREATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER");

            migrationBuilder.DropIndex(
                name: "IX_SURVEY_QUESTION_CREATED_USER_ID",
                table: "SURVEY_QUESTION");

            migrationBuilder.DropIndex(
                name: "IX_SURVEY_HISTORY_CREATED_USER_ID",
                table: "SURVEY_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_SURVEY_CREATED_USER_ID",
                table: "SURVEY");

            migrationBuilder.DropIndex(
                name: "IX_SLA_EVENTS_CREATED_USER_ID",
                table: "SLA_EVENTS");

            migrationBuilder.DropIndex(
                name: "IX_SLA_AREA_CREATED_USER_ID",
                table: "SLA_AREA");

            migrationBuilder.DropIndex(
                name: "IX_SLA_CREATED_USER_ID",
                table: "SLA");

            migrationBuilder.DropIndex(
                name: "IX_SERVICECATALOG_CREATED_USER_ID",
                table: "SERVICECATALOG");

            migrationBuilder.DropIndex(
                name: "IX_RULE_DETAIL_CREATED_USER_ID",
                table: "RULE_DETAIL");

            migrationBuilder.DropIndex(
                name: "IX_RULE_CREATED_USER_ID",
                table: "RULE");

            migrationBuilder.DropIndex(
                name: "IX_REGION_CREATED_USER_ID",
                table: "REGION");

            migrationBuilder.DropIndex(
                name: "IX_PASSWORD_CHANGE_HISTORY_CREATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_PARAMETER_TYPE_CREATED_USER_ID",
                table: "PARAMETER_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_PARAMETER_CREATED_USER_ID",
                table: "PARAMETER");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_NUMBERS_CREATED_USER_ID",
                table: "ORDER_NUMBERS");

            migrationBuilder.DropIndex(
                name: "IX_MAIN_PROCESS_CREATED_USER_ID",
                table: "MAIN_PROCESS");

            migrationBuilder.DropIndex(
                name: "IX_MAIL_TO_SEND_CREATED_USER_ID",
                table: "MAIL_TO_SEND");

            migrationBuilder.DropIndex(
                name: "IX_MAIL_SERVER_SETUP_CREATED_USER_ID",
                table: "MAIL_SERVER_SETUP");

            migrationBuilder.DropIndex(
                name: "IX_LOCATION_CREATED_USER_ID",
                table: "LOCATION");

            migrationBuilder.DropIndex(
                name: "IX_LEAVE_TYPE_CREATED_USER_ID",
                table: "LEAVE_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_LEAVE_CREATED_USER_ID",
                table: "LEAVE");

            migrationBuilder.DropIndex(
                name: "IX_LDAP_INFO_CREATED_USER_ID",
                table: "LDAP_INFO");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_SETTINGS_CREATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT");

            migrationBuilder.DropIndex(
                name: "IX_KNOWLEDGE_FILES_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_RESOLUTION_CREATED_USER_ID",
                table: "INCIDENT_RESOLUTION");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_HISTORY_CREATED_USER_ID",
                table: "INCIDENT_HISTORY");

            migrationBuilder.DropIndex(
                name: "IX_INCIDENT_CREATED_USER_ID",
                table: "INCIDENT");

            migrationBuilder.DropIndex(
                name: "IX_HOLDING_CREATED_USER_ID",
                table: "HOLDING");

            migrationBuilder.DropIndex(
                name: "IX_GROUP_TYPE_CREATED_USER_ID",
                table: "GROUP_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_GROUP_EXPERT_CREATED_USER_ID",
                table: "GROUP_EXPERT");

            migrationBuilder.DropIndex(
                name: "IX_GROUP_CREATED_USER_ID",
                table: "GROUP");

            migrationBuilder.DropIndex(
                name: "IX_EMAIL_TEMPLATE_CREATED_USER_ID",
                table: "EMAIL_TEMPLATE");

            migrationBuilder.DropIndex(
                name: "IX_DOMAIN_CREATED_USER_ID",
                table: "DOMAIN");

            migrationBuilder.DropIndex(
                name: "IX_DEPARTMENT_CREATED_USER_ID",
                table: "DEPARTMENT");

            migrationBuilder.DropIndex(
                name: "IX_COUNTRY_CREATED_USER_ID",
                table: "COUNTRY");

            migrationBuilder.DropIndex(
                name: "IX_COMPANY_CREATED_USER_ID",
                table: "COMPANY");

            migrationBuilder.DropIndex(
                name: "IX_CITY_CREATED_USER_ID",
                table: "CITY");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_WORKING_SCHEDULE_CREATED_USER_ID",
                table: "WORKING_SCHEDULE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WORKING_DAYS_CREATED_USER_ID",
                table: "WORKING_DAYS",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USERTYPE_MENU_CREATED_USER_ID",
                table: "USERTYPE_MENU",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_TYPE_CREATED_USER_ID",
                table: "USER_TYPE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_GROUP_CREATED_USER_ID",
                table: "USER_GROUP",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CREATED_USER_ID",
                table: "USER",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TITLE_CREATED_USER_ID",
                table: "TITLE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TIME_MANAGEMENT_OFFDAYS_CREATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TIME_MANAGEMENT_CREATED_USER_ID",
                table: "TIME_MANAGEMENT",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_QUESTION_ANSWER_CREATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_QUESTION_CREATED_USER_ID",
                table: "SURVEY_QUESTION",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_HISTORY_CREATED_USER_ID",
                table: "SURVEY_HISTORY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SURVEY_CREATED_USER_ID",
                table: "SURVEY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_EVENTS_CREATED_USER_ID",
                table: "SLA_EVENTS",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_AREA_CREATED_USER_ID",
                table: "SLA_AREA",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLA_CREATED_USER_ID",
                table: "SLA",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SERVICECATALOG_CREATED_USER_ID",
                table: "SERVICECATALOG",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RULE_DETAIL_CREATED_USER_ID",
                table: "RULE_DETAIL",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RULE_CREATED_USER_ID",
                table: "RULE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_REGION_CREATED_USER_ID",
                table: "REGION",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PASSWORD_CHANGE_HISTORY_CREATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_TYPE_CREATED_USER_ID",
                table: "PARAMETER_TYPE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETER_CREATED_USER_ID",
                table: "PARAMETER",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_NUMBERS_CREATED_USER_ID",
                table: "ORDER_NUMBERS",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAIN_PROCESS_CREATED_USER_ID",
                table: "MAIN_PROCESS",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAIL_TO_SEND_CREATED_USER_ID",
                table: "MAIL_TO_SEND",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MAIL_SERVER_SETUP_CREATED_USER_ID",
                table: "MAIL_SERVER_SETUP",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LOCATION_CREATED_USER_ID",
                table: "LOCATION",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_TYPE_CREATED_USER_ID",
                table: "LEAVE_TYPE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LEAVE_CREATED_USER_ID",
                table: "LEAVE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LDAP_INFO_CREATED_USER_ID",
                table: "LDAP_INFO",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_SETTINGS_CREATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_MANAGEMENT_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KNOWLEDGE_FILES_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_RESOLUTION_CREATED_USER_ID",
                table: "INCIDENT_RESOLUTION",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_HISTORY_CREATED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INCIDENT_CREATED_USER_ID",
                table: "INCIDENT",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_HOLDING_CREATED_USER_ID",
                table: "HOLDING",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_TYPE_CREATED_USER_ID",
                table: "GROUP_TYPE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_EXPERT_CREATED_USER_ID",
                table: "GROUP_EXPERT",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GROUP_CREATED_USER_ID",
                table: "GROUP",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EMAIL_TEMPLATE_CREATED_USER_ID",
                table: "EMAIL_TEMPLATE",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DOMAIN_CREATED_USER_ID",
                table: "DOMAIN",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENT_CREATED_USER_ID",
                table: "DEPARTMENT",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COUNTRY_CREATED_USER_ID",
                table: "COUNTRY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_CREATED_USER_ID",
                table: "COMPANY",
                column: "CREATED_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CITY_CREATED_USER_ID",
                table: "CITY",
                column: "CREATED_USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CITY_USER_CREATED_USER_ID",
                table: "CITY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COMPANY_USER_CREATED_USER_ID",
                table: "COMPANY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_COUNTRY_USER_CREATED_USER_ID",
                table: "COUNTRY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DEPARTMENT_USER_CREATED_USER_ID",
                table: "DEPARTMENT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DOMAIN_USER_CREATED_USER_ID",
                table: "DOMAIN",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EMAIL_TEMPLATE_USER_CREATED_USER_ID",
                table: "EMAIL_TEMPLATE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GROUP_USER_CREATED_USER_ID",
                table: "GROUP",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GROUP_EXPERT_USER_CREATED_USER_ID",
                table: "GROUP_EXPERT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GROUP_TYPE_USER_CREATED_USER_ID",
                table: "GROUP_TYPE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HOLDING_USER_CREATED_USER_ID",
                table: "HOLDING",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_USER_CREATED_USER_ID",
                table: "INCIDENT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_HISTORY_USER_CREATED_USER_ID",
                table: "INCIDENT_HISTORY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_INCIDENT_RESOLUTION_USER_CREATED_USER_ID",
                table: "INCIDENT_RESOLUTION",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_FILES_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_FILES",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_MANAGEMENT_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_MANAGEMENT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KNOWLEDGE_SETTINGS_USER_CREATED_USER_ID",
                table: "KNOWLEDGE_SETTINGS",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LDAP_INFO_USER_CREATED_USER_ID",
                table: "LDAP_INFO",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LEAVE_USER_CREATED_USER_ID",
                table: "LEAVE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LEAVE_TYPE_USER_CREATED_USER_ID",
                table: "LEAVE_TYPE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LOCATION_USER_CREATED_USER_ID",
                table: "LOCATION",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MAIL_SERVER_SETUP_USER_CREATED_USER_ID",
                table: "MAIL_SERVER_SETUP",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MAIL_TO_SEND_USER_CREATED_USER_ID",
                table: "MAIL_TO_SEND",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MAIN_PROCESS_USER_CREATED_USER_ID",
                table: "MAIN_PROCESS",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_NUMBERS_USER_CREATED_USER_ID",
                table: "ORDER_NUMBERS",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PARAMETER_USER_CREATED_USER_ID",
                table: "PARAMETER",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PARAMETER_TYPE_USER_CREATED_USER_ID",
                table: "PARAMETER_TYPE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PASSWORD_CHANGE_HISTORY_USER_CREATED_USER_ID",
                table: "PASSWORD_CHANGE_HISTORY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_REGION_USER_CREATED_USER_ID",
                table: "REGION",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RULE_USER_CREATED_USER_ID",
                table: "RULE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RULE_DETAIL_USER_CREATED_USER_ID",
                table: "RULE_DETAIL",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SERVICECATALOG_USER_CREATED_USER_ID",
                table: "SERVICECATALOG",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SLA_USER_CREATED_USER_ID",
                table: "SLA",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SLA_AREA_USER_CREATED_USER_ID",
                table: "SLA_AREA",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SLA_EVENTS_USER_CREATED_USER_ID",
                table: "SLA_EVENTS",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SURVEY_USER_CREATED_USER_ID",
                table: "SURVEY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SURVEY_HISTORY_USER_CREATED_USER_ID",
                table: "SURVEY_HISTORY",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SURVEY_QUESTION_USER_CREATED_USER_ID",
                table: "SURVEY_QUESTION",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SURVEY_QUESTION_ANSWER_USER_CREATED_USER_ID",
                table: "SURVEY_QUESTION_ANSWER",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TIME_MANAGEMENT_USER_CREATED_USER_ID",
                table: "TIME_MANAGEMENT",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TIME_MANAGEMENT_OFFDAYS_USER_CREATED_USER_ID",
                table: "TIME_MANAGEMENT_OFFDAYS",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TITLE_USER_CREATED_USER_ID",
                table: "TITLE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_USER_CREATED_USER_ID",
                table: "USER",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_GROUP_USER_CREATED_USER_ID",
                table: "USER_GROUP",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USER_TYPE_USER_CREATED_USER_ID",
                table: "USER_TYPE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_USERTYPE_MENU_USER_CREATED_USER_ID",
                table: "USERTYPE_MENU",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WORKING_DAYS_USER_CREATED_USER_ID",
                table: "WORKING_DAYS",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WORKING_SCHEDULE_USER_CREATED_USER_ID",
                table: "WORKING_SCHEDULE",
                column: "CREATED_USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
