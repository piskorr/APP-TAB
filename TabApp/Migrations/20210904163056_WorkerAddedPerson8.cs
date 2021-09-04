using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class WorkerAddedPerson8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worker_PersonID",
                table: "Worker");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PersonID",
                table: "Worker",
                column: "PersonID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Worker_PersonID",
                table: "Worker");

            migrationBuilder.CreateIndex(
                name: "IX_Worker_PersonID",
                table: "Worker",
                column: "PersonID");
        }
    }
}
