using Microsoft.EntityFrameworkCore.Migrations;

namespace Manager.Infrastructure.Migrations.ManagerMigrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(36)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(90)", maxLength: 90, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
