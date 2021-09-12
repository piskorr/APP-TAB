using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TabApp.Migrations
{
    public partial class newReopair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Repair",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Repair",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Repair",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Repair",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Repair_Item_ItemID",
                table: "Repair",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
