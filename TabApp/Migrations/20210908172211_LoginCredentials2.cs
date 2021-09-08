using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class LoginCredentials2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginCredentials",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginCredentials", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoginCredentials_Person_ID",
                        column: x => x.ID,
                        principalTable: "Person",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginCredentials");
        }
    }
}
