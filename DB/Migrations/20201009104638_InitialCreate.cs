using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNum = table.Column<int>(nullable: false),
                    NumberCarBody = table.Column<string>(nullable: true),
                    EngineNumber = table.Column<int>(nullable: false),
                    DateSheetNumber = table.Column<DateTime>(nullable: false),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    DateOfRegistration = table.Column<DateTime>(nullable: false),
                    COLOR = table.Column<string>(nullable: true),
                    TechInspection = table.Column<string>(nullable: true),
                    DateTechInspection = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CarsStolens",
                columns: table => new
                {
                    DateStolen = table.Column<DateTime>(nullable: false),
                    DateAppeal = table.Column<DateTime>(nullable: false),
                    Circumstances = table.Column<string>(nullable: true),
                    MarkFind = table.Column<bool>(nullable: false),
                    DateFind = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "BrandAutos",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyManufacturer = table.Column<string>(nullable: true),
                    CountryManufacturer = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    StartProduction = table.Column<DateTime>(nullable: false),
                    EndProduction = table.Column<DateTime>(nullable: false),
                    Specifications = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AutoID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandAutos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BrandAutos_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    PassportData = table.Column<string>(nullable: true),
                    DriversLicenseNum = table.Column<int>(nullable: false),
                    DateIssueCertificate = table.Column<DateTime>(nullable: false),
                    EndDateCertificate = table.Column<DateTime>(nullable: false),
                    CategoryCertificate = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AutoID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drivers_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Age = table.Column<short>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    PassportData = table.Column<string>(nullable: true),
                    AutoID = table.Column<long>(nullable: true),
                    DriverID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Staffs_Autos_AutoID",
                        column: x => x.AutoID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Drivers_DriverID",
                        column: x => x.DriverID,
                        principalTable: "Drivers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePosition = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    Duties = table.Column<string>(nullable: true),
                    Requirements = table.Column<string>(nullable: true),
                    StaffID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Positions_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameRank = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    Duties = table.Column<string>(nullable: true),
                    Requirements = table.Column<string>(nullable: true),
                    StaffID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ranks_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandAutos_AutoID",
                table: "BrandAutos",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AutoID",
                table: "Drivers",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_StaffID",
                table: "Positions",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_StaffID",
                table: "Ranks",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_AutoID",
                table: "Staffs",
                column: "AutoID");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DriverID",
                table: "Staffs",
                column: "DriverID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BrandAutos");

            migrationBuilder.DropTable(
                name: "CarsStolens");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Autos");
        }
    }
}
