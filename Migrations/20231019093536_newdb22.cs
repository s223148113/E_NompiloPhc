using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_NompiloPhc.Migrations
{
    public partial class newdb22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anthropometry_PatientInfos_PatientInfoID",
                table: "Anthropometry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Anthropometry",
                table: "Anthropometry");

            migrationBuilder.RenameTable(
                name: "UserInputModel",
                newName: "UserInputModels");

            migrationBuilder.RenameTable(
                name: "Anthropometry",
                newName: "Antropometry");

            migrationBuilder.RenameIndex(
                name: "IX_Anthropometry_PatientInfoID",
                table: "Antropometry",
                newName: "IX_Antropometry_PatientInfoID");

            migrationBuilder.AddColumn<string>(
                name: "DeliverLastName",
                table: "MedicationRefillDelivery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliverName",
                table: "MedicationRefillDelivery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliverYesNo",
                table: "MedicationRefillDelivery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryArrival",
                table: "MedicationRefillDelivery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeliveryDepartment",
                table: "MedicationRefillDelivery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartDate",
                table: "MedicationRefillDelivery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DoctorApprover",
                table: "MedicationRefillDelivery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PHCName",
                table: "MedicationRefillDelivery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PatientInfoID",
                table: "FoodItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Antropometry",
                table: "Antropometry",
                column: "anthroID");

            migrationBuilder.CreateTable(
                name: "Screening2",
                columns: table => new
                {
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtremeBMI = table.Column<double>(type: "float", nullable: false),
                    WeightLoss = table.Column<double>(type: "float", nullable: false),
                    ReducedIntake = table.Column<double>(type: "float", nullable: false),
                    SevereIllness = table.Column<double>(type: "float", nullable: false),
                    RiskScore = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screening2", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screening2_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID");
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChosenContraceptiveId = table.Column<int>(type: "int", nullable: false),
                    DateOfChoice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTrackingModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrackingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MenstrualCycleDay = table.Column<int>(type: "int", nullable: false),
                    BasalBodyTemperature = table.Column<double>(type: "float", nullable: false),
                    HasOvulationTest = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrackingModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Screening2_PatientInfoID",
                table: "Screening2",
                column: "PatientInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Antropometry_PatientInfos_PatientInfoID",
                table: "Antropometry",
                column: "PatientInfoID",
                principalTable: "PatientInfos",
                principalColumn: "PatientInfoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Antropometry_PatientInfos_PatientInfoID",
                table: "Antropometry");

            migrationBuilder.DropTable(
                name: "Screening2");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "UserTrackingModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Antropometry",
                table: "Antropometry");

            migrationBuilder.DropColumn(
                name: "DeliverLastName",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "DeliverName",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "DeliverYesNo",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "DeliveryArrival",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "DeliveryDepartment",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "DepartDate",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "DoctorApprover",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "PHCName",
                table: "MedicationRefillDelivery");

            migrationBuilder.DropColumn(
                name: "PatientInfoID",
                table: "FoodItems");

            migrationBuilder.RenameTable(
                name: "UserInputModels",
                newName: "UserInputModel");

            migrationBuilder.RenameTable(
                name: "Antropometry",
                newName: "Anthropometry");

            migrationBuilder.RenameIndex(
                name: "IX_Antropometry_PatientInfoID",
                table: "Anthropometry",
                newName: "IX_Anthropometry_PatientInfoID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Anthropometry",
                table: "Anthropometry",
                column: "anthroID");

            migrationBuilder.AddForeignKey(
                name: "FK_Anthropometry_PatientInfos_PatientInfoID",
                table: "Anthropometry",
                column: "PatientInfoID",
                principalTable: "PatientInfos",
                principalColumn: "PatientInfoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
