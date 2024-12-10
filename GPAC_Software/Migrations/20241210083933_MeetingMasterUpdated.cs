using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GPAC_Software.Migrations
{
    /// <inheritdoc />
    public partial class MeetingMasterUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttendeesClientSide",
                table: "MeetingMinutesMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AttendeesHostSide",
                table: "MeetingMinutesMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingAgenda",
                table: "MeetingMinutesMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingDecision",
                table: "MeetingMinutesMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingDiscussion",
                table: "MeetingMinutesMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MeetingPlace",
                table: "MeetingMinutesMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttendeesClientSide",
                table: "MeetingMinutesMasters");

            migrationBuilder.DropColumn(
                name: "AttendeesHostSide",
                table: "MeetingMinutesMasters");

            migrationBuilder.DropColumn(
                name: "MeetingAgenda",
                table: "MeetingMinutesMasters");

            migrationBuilder.DropColumn(
                name: "MeetingDecision",
                table: "MeetingMinutesMasters");

            migrationBuilder.DropColumn(
                name: "MeetingDiscussion",
                table: "MeetingMinutesMasters");

            migrationBuilder.DropColumn(
                name: "MeetingPlace",
                table: "MeetingMinutesMasters");
        }
    }
}
