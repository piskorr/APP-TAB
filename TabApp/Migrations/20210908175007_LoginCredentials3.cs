using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class LoginCredentials3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginCredentials_Person_PersonID",
                table: "LoginCredentials");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "LoginCredentials");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginCredentials_Person_ID",
                table: "LoginCredentials",
                column: "ID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginCredentials_Person_ID",
                table: "LoginCredentials");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "LoginCredentials",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginCredentials_Person_PersonID",
                table: "LoginCredentials",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
