using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace toDoListApp.Migrations
{
    /// <inheritdoc />
    public partial class updateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_toDoItems",
                table: "toDoItems");

            migrationBuilder.RenameTable(
                name: "toDoItems",
                newName: "ToDoItems");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ToDoItems",
                newName: "Task");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDoItems",
                table: "ToDoItems");

            migrationBuilder.RenameTable(
                name: "ToDoItems",
                newName: "toDoItems");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "toDoItems",
                newName: "Title");

            migrationBuilder.AddPrimaryKey(
                name: "PK_toDoItems",
                table: "toDoItems",
                column: "Id");
        }
    }
}
