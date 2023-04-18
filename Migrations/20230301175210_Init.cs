using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_IndividualWork_KazanovAlexandr.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClinicDepartment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ClinicDepartment_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OutpatientCard",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OutpatientCard_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Position_PK", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complaints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutpatientCardID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patient_OutpatientCard",
                        column: x => x.OutpatientCardID,
                        principalTable: "OutpatientCard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: false),
                    ClinicDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Doctor_ClinicDepartment_ClinicDepartmentId",
                        column: x => x.ClinicDepartmentId,
                        principalTable: "ClinicDepartment",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Doctor_OutpatientCard",
                        column: x => x.ID,
                        principalTable: "OutpatientCard",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Position",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ClinicDepartmentId",
                table: "Doctor",
                column: "ClinicDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_PositionID",
                table: "Doctor",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_OutpatientCardID",
                table: "Patient",
                column: "OutpatientCardID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "ClinicDepartment");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "OutpatientCard");
        }
    }
}
