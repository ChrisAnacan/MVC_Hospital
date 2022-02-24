using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_MVC.Migrations
{
    public partial class AddingApplicantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantsTables",
                table: "ApplicantsTables");

            migrationBuilder.RenameTable(
                name: "ApplicantsTables",
                newName: "ApplicantsTable");

            migrationBuilder.RenameColumn(
                name: "Doctor_Name",
                table: "ApplicantsTable",
                newName: "Applicant_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantsTable",
                table: "ApplicantsTable",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicantsTable",
                table: "ApplicantsTable");

            migrationBuilder.RenameTable(
                name: "ApplicantsTable",
                newName: "ApplicantsTables");

            migrationBuilder.RenameColumn(
                name: "Applicant_Name",
                table: "ApplicantsTables",
                newName: "Doctor_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicantsTables",
                table: "ApplicantsTables",
                column: "ID");
        }
    }
}
