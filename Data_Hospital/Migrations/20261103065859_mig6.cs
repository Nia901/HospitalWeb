using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Kazanluk", 100, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hospital@email.com", false, "MBAL Kazanluk", "123-456-7890" },
                    { 2, "Stara Zagora", 150, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "countyhospital@email.com", false, "Umbal Stara Zagora", "987-654-3210" },
                    { 3, "Plovdiv", 200, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "plovdivhospital@email.com", false, "MBAL Plovdiv", "032-555-1234" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ivanpetrov1@abv.bg", "Ivan", "Petrov", "0888 123 456" },
                    { 2, "petarivanov1@abv.bg", "Petar", "Ivanov", "0888 123 457" },
                    { 3, "iordaniordanov1@abv.bg", "Iordan", "Iordanov", "0888 123 458" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "FirstName", "HospitalId", "LastName", "PhoneNumber", "Specialty" },
                values: new object[,]
                {
                    { 1, "johnsmith@abv.bg", "Dr. John", 1, "Smith", "0888 123 456", "Cardiology" },
                    { 2, "kirlimanolov@abv.bg", "Dr. Kiril", 2, "Manolov", "0888 123 457", "Neurology" },
                    { 3, "petarjohnson@abv.bg", "Dr. Peter", 3, "Jonhson", "0888 123 459", "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatients",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
