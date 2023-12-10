using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class init666 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_slots_Appointments_appointmentId",
                table: "slots");

            migrationBuilder.DropForeignKey(
                name: "FK_slots_patients_patientId",
                table: "slots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_slots",
                table: "slots");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda232fe-318b-46b8-97d9-43708bdc5179");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8f31242-9cdc-4080-9500-7818a40beab7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3f0e58fb-0b38-4f73-a189-54c625662d7b", "3ae1f128-2d85-464f-b455-7fa8340a9aa4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f0e58fb-0b38-4f73-a189-54c625662d7b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3ae1f128-2d85-464f-b455-7fa8340a9aa4");

            migrationBuilder.RenameTable(
                name: "slots",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_slots_patientId",
                table: "Bookings",
                newName: "IX_Bookings_patientId");

            migrationBuilder.RenameIndex(
                name: "IX_slots_appointmentId",
                table: "Bookings",
                newName: "IX_Bookings_appointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0711e7b6-da25-4abb-a5a7-feee8ba1b50d", "9bba7962-cf7b-4f37-b81d-50d590a8da0e", "Admin", "admin" },
                    { "2b85294d-886c-43f1-9f85-5032cc5683b6", "ceec487f-4610-473f-af52-74c2d270609e", "Doctor", "doctor" },
                    { "8307a8f9-f72b-4e9e-ac4c-da6e0c8098ef", "e7b901c2-dd5c-4611-89c4-4cc3ce9da578", "Patient", "patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DoctorId", "Email", "EmailConfirmed", "FirstName", "ImageData", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "gender", "patientId", "role" },
                values: new object[] { "b2e46542-6907-4148-a730-219309c6fa32", 0, "fb0c7274-3435-4439-9000-bd3b4cad4006", null, null, "admin@email.com", true, null, null, null, false, null, "admin@email.com", null, "AQAAAAEAACcQAAAAEBK7e2AmxtxfnGXcAhMhlofOIG6JJT68lK0g+FjHmGMgfb6gHn8jSGwiB6OOADCfEA==", null, false, "13fe6207-af93-42a1-a06b-0a95c3769213", false, null, null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0711e7b6-da25-4abb-a5a7-feee8ba1b50d", "b2e46542-6907-4148-a730-219309c6fa32" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Appointments_appointmentId",
                table: "Bookings",
                column: "appointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_patients_patientId",
                table: "Bookings",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Appointments_appointmentId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_patients_patientId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b85294d-886c-43f1-9f85-5032cc5683b6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8307a8f9-f72b-4e9e-ac4c-da6e0c8098ef");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0711e7b6-da25-4abb-a5a7-feee8ba1b50d", "b2e46542-6907-4148-a730-219309c6fa32" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0711e7b6-da25-4abb-a5a7-feee8ba1b50d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2e46542-6907-4148-a730-219309c6fa32");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "slots");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_patientId",
                table: "slots",
                newName: "IX_slots_patientId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_appointmentId",
                table: "slots",
                newName: "IX_slots_appointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_slots",
                table: "slots",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f0e58fb-0b38-4f73-a189-54c625662d7b", "f7507db9-7edc-4337-a604-88f8a62c653f", "Admin", "admin" },
                    { "bda232fe-318b-46b8-97d9-43708bdc5179", "eab0612a-e60c-4c9e-a7f0-77bbc2729bc6", "Doctor", "doctor" },
                    { "c8f31242-9cdc-4080-9500-7818a40beab7", "545aa624-0221-4b3d-a49c-6226ad12426d", "Patient", "patient" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DoctorId", "Email", "EmailConfirmed", "FirstName", "ImageData", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "gender", "patientId", "role" },
                values: new object[] { "3ae1f128-2d85-464f-b455-7fa8340a9aa4", 0, "ac6b3ce3-30e7-48a0-a6e0-7276ae5a088b", null, null, "admin@email.com", true, null, null, null, false, null, "admin@email.com", null, "AQAAAAEAACcQAAAAEAu/ZKa2WCAlJF1XLaWsyFA7qSnKNxGz8+FHfOnjJ5grF+OB1URD0ZE5G/SQX0R9og==", null, false, "c250b6f4-e156-4fe4-b1df-687a62e9f73f", false, null, null, null, 0 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3f0e58fb-0b38-4f73-a189-54c625662d7b", "3ae1f128-2d85-464f-b455-7fa8340a9aa4" });

            migrationBuilder.AddForeignKey(
                name: "FK_slots_Appointments_appointmentId",
                table: "slots",
                column: "appointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_slots_patients_patientId",
                table: "slots",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id");
        }
    }
}
