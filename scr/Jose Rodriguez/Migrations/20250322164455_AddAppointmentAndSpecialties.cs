using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jose_Rodriguez.Migrations
{
    public partial class AddAppointmentAndSpecialties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppointmentDate",
                table: "Patients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "AppointmentTime",
                table: "Patients",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialtiesString",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDate",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AppointmentTime",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SpecialtiesString",
                table: "Patients");
        }
    }
}
