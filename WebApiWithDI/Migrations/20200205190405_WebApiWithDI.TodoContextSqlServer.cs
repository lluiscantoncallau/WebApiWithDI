using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiWithDI.Migrations
{
    public partial class WebApiWithDITodoContextSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoItemSqlServer",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemSqlServer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TodoItemSqlServer",
                columns: new[] { "Id", "FirstName", "IsComplete" },
                values: new object[,]
                {
                    { 1L, "Lluis", true },
                    { 2L, "Josep", true },
                    { 3L, "Enric", true },
                    { 4L, "Ricard", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItemSqlServer");
        }
    }
}
