using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoAPI.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_ToDoLists_ToDoListId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_ToDoListId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ToDoListId",
                table: "ToDos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ToDoListId",
                table: "ToDos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ToDoListId",
                table: "ToDos",
                column: "ToDoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_ToDoLists_ToDoListId",
                table: "ToDos",
                column: "ToDoListId",
                principalTable: "ToDoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
