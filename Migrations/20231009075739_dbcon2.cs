using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_NompiloPhc.Migrations
{
    public partial class dbcon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentViewModels",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    CounselorsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CounselorId = table.Column<int>(type: "int", nullable: false),
                    CounselorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyTemperature = table.Column<int>(type: "int", nullable: false),
                    OxygenLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PulseRate = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    BloodPressure = table.Column<int>(type: "int", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Therapy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedMedication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckUpNurse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckUp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContraceptiveMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectivenessRate = table.Column<double>(type: "float", nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EligibilityCriteria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraceptiveMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContraceptivePreferencesViewModels",
                columns: table => new
                {
                    UserAge = table.Column<int>(type: "int", nullable: false),
                    SelectedContraceptive = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Contraceptives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effectiveness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsageInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contraceptives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CounselingResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounselingResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Counselors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counselors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ExchangeCurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_Currencies_ExchangeCurrencyId",
                        column: x => x.ExchangeCurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilityDataViewModels",
                columns: table => new
                {
                    MenstrualCycleLength = table.Column<int>(type: "int", nullable: false),
                    LastMenstrualPeriodStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FertilityInsights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsightsText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FertileDays = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilityInsights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilityInsightsViewModels",
                columns: table => new
                {
                    MostFertileDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OvulationDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsightsText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FertileDays = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ServingSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Carbohydrates = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    Vitamins = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Minerals = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodID);
                });

            migrationBuilder.CreateTable(
                name: "HealthProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSupplyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSupplyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSupplyProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSupplyProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicationRefillDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRefillDelivery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientInfos",
                columns: table => new
                {
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Citizenship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Ward = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Room = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AttendingDoctor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dietitian = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NextOfKin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NextOfKinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientInfos", x => x.PatientInfoID);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicationRefill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprintCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicationRefill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "patientViewModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientViewModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PHCMedicationRefill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacistLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImprintCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicationSupplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHCMedicationRefill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffLogTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vacation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sick = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Regular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffLogTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInputModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false),
                    Smokes = table.Column<bool>(type: "bit", nullable: false),
                    HasMedicalCondition = table.Column<bool>(type: "bit", nullable: false),
                    MedicalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredContraceptiveMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "VirtualAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualAppointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkInAppointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForVisit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkInAppointment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anthropometry",
                columns: table => new
                {
                    anthroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    height = table.Column<double>(type: "float", nullable: false),
                    currentWeight = table.Column<double>(type: "float", nullable: false),
                    bmi = table.Column<double>(type: "float", nullable: false),
                    usualWeight = table.Column<double>(type: "float", nullable: false),
                    waistCircumference = table.Column<double>(type: "float", nullable: false),
                    hipCircumference = table.Column<double>(type: "float", nullable: false),
                    armCircumference = table.Column<double>(type: "float", nullable: false),
                    calfCircumference = table.Column<double>(type: "float", nullable: false),
                    tricepSkinFold = table.Column<double>(type: "float", nullable: false),
                    subscapularSkinFold = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anthropometry", x => x.anthroID);
                    table.ForeignKey(
                        name: "FK_Anthropometry_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biochemicals",
                columns: table => new
                {
                    BioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmokingFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uricAcid = table.Column<double>(type: "float", nullable: false),
                    cholesterol = table.Column<double>(type: "float", nullable: false),
                    totalProtein = table.Column<double>(type: "float", nullable: false),
                    albumin = table.Column<double>(type: "float", nullable: false),
                    globulin = table.Column<double>(type: "float", nullable: false),
                    amylase = table.Column<double>(type: "float", nullable: false),
                    lipase = table.Column<double>(type: "float", nullable: false),
                    hemoglobin = table.Column<double>(type: "float", nullable: false),
                    sodium = table.Column<double>(type: "float", nullable: false),
                    potassium = table.Column<double>(type: "float", nullable: false),
                    calcium = table.Column<double>(type: "float", nullable: false),
                    magnesium = table.Column<double>(type: "float", nullable: false),
                    ammonia = table.Column<double>(type: "float", nullable: false),
                    bleedingTime = table.Column<double>(type: "float", nullable: false),
                    clottingTime = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biochemicals", x => x.BioID);
                    table.ForeignKey(
                        name: "FK_Biochemicals_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DietaryInfo",
                columns: table => new
                {
                    DietaryInfoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakfastFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakfastMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BreakfastAmount = table.Column<double>(type: "float", nullable: false),
                    BreakfastTotalCalories = table.Column<double>(type: "float", nullable: false),
                    AMSnackFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMSnackMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMSnackAmount = table.Column<double>(type: "float", nullable: false),
                    AMSnacktotalclories = table.Column<double>(type: "float", nullable: false),
                    LunchFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LunchMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LunchAmount = table.Column<double>(type: "float", nullable: false),
                    LunchTotalCalories = table.Column<double>(type: "float", nullable: false),
                    PMSnackFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PMSnackMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PMSnackAmout = table.Column<double>(type: "float", nullable: false),
                    PMSnackTotalCalories = table.Column<double>(type: "float", nullable: false),
                    DinnerFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DinnerMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DinnerAmount = table.Column<double>(type: "float", nullable: false),
                    DinnerTotalCalories = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryInfo", x => x.DietaryInfoID);
                    table.ForeignKey(
                        name: "FK_DietaryInfo_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FamilyHistory",
                columns: table => new
                {
                    FamilyHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardiovascularDisease = table.Column<bool>(type: "bit", nullable: false),
                    NeuromuscularDisease = table.Column<bool>(type: "bit", nullable: false),
                    GastrointestinalDisease = table.Column<bool>(type: "bit", nullable: false),
                    KidneyDisease = table.Column<bool>(type: "bit", nullable: false),
                    EndocrineDisease = table.Column<bool>(type: "bit", nullable: false),
                    DiabetesMellitusType1 = table.Column<bool>(type: "bit", nullable: false),
                    DiabetesMellitusType2 = table.Column<bool>(type: "bit", nullable: false),
                    PulmonaryDisease = table.Column<bool>(type: "bit", nullable: false),
                    Cancer = table.Column<bool>(type: "bit", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyHistory", x => x.FamilyHistoryID);
                    table.ForeignKey(
                        name: "FK_FamilyHistory_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodExchange",
                columns: table => new
                {
                    FoodExchangeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Breakfast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMSnack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lunch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PMSnack = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinnerSupper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodExchange", x => x.FoodExchangeID);
                    table.ForeignKey(
                        name: "FK_FoodExchange_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MacroNutrients",
                columns: table => new
                {
                    MacroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Factor = table.Column<double>(type: "float", nullable: false),
                    TeriLbw = table.Column<double>(type: "float", nullable: false),
                    TeriAbw = table.Column<double>(type: "float", nullable: false),
                    TeriCbw = table.Column<double>(type: "float", nullable: false),
                    KCal = table.Column<int>(type: "int", nullable: false),
                    ChongKg = table.Column<double>(type: "float", nullable: false),
                    Cho = table.Column<double>(type: "float", nullable: false),
                    Chon = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MacroNutrients", x => x.MacroID);
                    table.ForeignKey(
                        name: "FK_MacroNutrients_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalH",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PastIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentIllness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodAllergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalH", x => x.MedicalHistoryID);
                    table.ForeignKey(
                        name: "FK_MedicalH_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Screening",
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
                    table.PrimaryKey("PK_Screening", x => x.ScreeningId);
                    table.ForeignKey(
                        name: "FK_Screening_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID");
                });

            migrationBuilder.CreateTable(
                name: "SGA",
                columns: table => new
                {
                    SgaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightLoss = table.Column<double>(type: "float", nullable: false),
                    FoodIntake = table.Column<int>(type: "int", nullable: false),
                    GastrointestinalSymptom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunctionalCapacity = table.Column<int>(type: "int", nullable: false),
                    NutritionalRequirementDisease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhysicalExam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdemaPresence = table.Column<bool>(type: "bit", nullable: false),
                    AlbuminSGA = table.Column<double>(type: "float", nullable: false),
                    BMI = table.Column<double>(type: "float", nullable: false),
                    TIC = table.Column<int>(type: "int", nullable: false),
                    TotalScore = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SGA", x => x.SgaID);
                    table.ForeignKey(
                        name: "FK_SGA_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialHistory",
                columns: table => new
                {
                    SocialHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmokingFrequency = table.Column<int>(type: "int", nullable: false),
                    AlcoholType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholFrequency = table.Column<int>(type: "int", nullable: false),
                    AlcoholQuantity = table.Column<int>(type: "int", nullable: false),
                    PhysActivity = table.Column<int>(type: "int", nullable: false),
                    PatientInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialHistory", x => x.SocialHistoryID);
                    table.ForeignKey(
                        name: "FK_SocialHistory_PatientInfos_PatientInfoID",
                        column: x => x.PatientInfoID,
                        principalTable: "PatientInfos",
                        principalColumn: "PatientInfoID");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CounselorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Counselors_CounselorId",
                        column: x => x.CounselorId,
                        principalTable: "Counselors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CounselingRequestModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounselingRequestModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CounselingRequestModel_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FertilityData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CycleStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BasalBodyTemperature = table.Column<double>(type: "float", nullable: false),
                    CervicalMucusQuality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilityData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilityData_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSupplies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cost = table.Column<decimal>(type: "smallmoney", nullable: false),
                    Price = table.Column<decimal>(type: "smallmoney", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MedicalSupplyGroupId = table.Column<int>(type: "int", nullable: false),
                    MedicalSupplyProfileId = table.Column<int>(type: "int", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSupplies", x => x.Code);
                    table.ForeignKey(
                        name: "FK_MedicalSupplies_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalSupplies_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalSupplies_MedicalSupplyGroups_MedicalSupplyGroupId",
                        column: x => x.MedicalSupplyGroupId,
                        principalTable: "MedicalSupplyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalSupplies_MedicalSupplyProfiles_MedicalSupplyProfileId",
                        column: x => x.MedicalSupplyProfileId,
                        principalTable: "MedicalSupplyProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalSupplies_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefId = table.Column<int>(type: "int", nullable: false),
                    MedicalSupplyCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Quantity = table.Column<decimal>(type: "smallmoney", nullable: false),
                    ForeignPrice = table.Column<decimal>(type: "smallmoney", nullable: false),
                    PriceInBaseCurr = table.Column<decimal>(type: "smallmoney", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefDetails_MedicalSupplies_MedicalSupplyCode",
                        column: x => x.MedicalSupplyCode,
                        principalTable: "MedicalSupplies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anthropometry_PatientInfoID",
                table: "Anthropometry",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CounselorId",
                table: "Appointments",
                column: "CounselorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Biochemicals_PatientInfoID",
                table: "Biochemicals",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CounselingRequestModel_PatientId",
                table: "CounselingRequestModel",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_ExchangeCurrencyId",
                table: "Currencies",
                column: "ExchangeCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DietaryInfo_PatientInfoID",
                table: "DietaryInfo",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyHistory_PatientInfoID",
                table: "FamilyHistory",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FertilityData_PatientId",
                table: "FertilityData",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodExchange_PatientInfoID",
                table: "FoodExchange",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MacroNutrients_PatientInfoID",
                table: "MacroNutrients",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalH_PatientInfoID",
                table: "MedicalH",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplies_BrandId",
                table: "MedicalSupplies",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplies_CategoryId",
                table: "MedicalSupplies",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplies_MedicalSupplyGroupId",
                table: "MedicalSupplies",
                column: "MedicalSupplyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplies_MedicalSupplyProfileId",
                table: "MedicalSupplies",
                column: "MedicalSupplyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSupplies_UnitId",
                table: "MedicalSupplies",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RefDetails_MedicalSupplyCode",
                table: "RefDetails",
                column: "MedicalSupplyCode");

            migrationBuilder.CreateIndex(
                name: "IX_Screening_PatientInfoID",
                table: "Screening",
                column: "PatientInfoID",
                unique: true,
                filter: "[PatientInfoID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SGA_PatientInfoID",
                table: "SGA",
                column: "PatientInfoID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SocialHistory_PatientInfoID",
                table: "SocialHistory",
                column: "PatientInfoID",
                unique: true,
                filter: "[PatientInfoID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anthropometry");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentViewModels");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Biochemicals");

            migrationBuilder.DropTable(
                name: "CheckUp");

            migrationBuilder.DropTable(
                name: "ContraceptiveMethods");

            migrationBuilder.DropTable(
                name: "ContraceptivePreferencesViewModels");

            migrationBuilder.DropTable(
                name: "Contraceptives");

            migrationBuilder.DropTable(
                name: "CounselingRequestModel");

            migrationBuilder.DropTable(
                name: "CounselingResources");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "DietaryInfo");

            migrationBuilder.DropTable(
                name: "FamilyHistory");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "FertilityData");

            migrationBuilder.DropTable(
                name: "FertilityDataViewModels");

            migrationBuilder.DropTable(
                name: "FertilityInsights");

            migrationBuilder.DropTable(
                name: "FertilityInsightsViewModels");

            migrationBuilder.DropTable(
                name: "FoodExchange");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "HealthProviders");

            migrationBuilder.DropTable(
                name: "MacroNutrients");

            migrationBuilder.DropTable(
                name: "MedicalH");

            migrationBuilder.DropTable(
                name: "MedicationRefillDelivery");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PatientMedicationRefill");

            migrationBuilder.DropTable(
                name: "patientViewModels");

            migrationBuilder.DropTable(
                name: "PHCMedicationRefill");

            migrationBuilder.DropTable(
                name: "RefDetails");

            migrationBuilder.DropTable(
                name: "Screening");

            migrationBuilder.DropTable(
                name: "SGA");

            migrationBuilder.DropTable(
                name: "SocialHistory");

            migrationBuilder.DropTable(
                name: "StaffLogTime");

            migrationBuilder.DropTable(
                name: "UserInputModel");

            migrationBuilder.DropTable(
                name: "VirtualAppointment");

            migrationBuilder.DropTable(
                name: "WalkInAppointment");

            migrationBuilder.DropTable(
                name: "Counselors");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "MedicalSupplies");

            migrationBuilder.DropTable(
                name: "PatientInfos");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MedicalSupplyGroups");

            migrationBuilder.DropTable(
                name: "MedicalSupplyProfiles");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
