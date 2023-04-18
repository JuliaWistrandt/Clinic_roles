using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_IndividualWork_KazanovAlexandr.Migrations
{
    /// <inheritdoc />
    public partial class Initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_OutpatientCard",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_OutpatientCard",
                table: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_Patient_OutpatientCardID",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "OutpatientCardID",
                table: "Patient");


            migrationBuilder.CreateIndex(
                name: "IX_OutpatientCard_DoctorID",
                table: "OutpatientCard",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_OutpatientCard_PatientID",
                table: "OutpatientCard",
                column: "PatientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_OutpatientCard",
                table: "OutpatientCard",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_OutpatientCard",
                table: "OutpatientCard",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_OutpatientCard",
                table: "OutpatientCard");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_OutpatientCard",
                table: "OutpatientCard");

            migrationBuilder.DropIndex(
                name: "IX_OutpatientCard_DoctorID",
                table: "OutpatientCard");

            migrationBuilder.DropIndex(
                name: "IX_OutpatientCard_PatientID",
                table: "OutpatientCard");

            migrationBuilder.AddColumn<int>(
                name: "OutpatientCardID",
                table: "Patient",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Doctor",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_OutpatientCardID",
                table: "Patient",
                column: "OutpatientCardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_OutpatientCard",
                table: "Doctor",
                column: "ID",
                principalTable: "OutpatientCard",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_OutpatientCard",
                table: "Patient",
                column: "OutpatientCardID",
                principalTable: "OutpatientCard",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
