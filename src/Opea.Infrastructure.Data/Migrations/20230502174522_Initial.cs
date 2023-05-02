using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opea.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanySize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanySize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_CompanySize_CompanySize",
                        column: x => x.CompanySize,
                        principalTable: "CompanySize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CompanySize",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Small" });

            migrationBuilder.InsertData(
                table: "CompanySize",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Medium" });

            migrationBuilder.InsertData(
                table: "CompanySize",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Large" });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CompanySize",
                table: "Client",
                column: "CompanySize");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "CompanySize");
        }
    }
}
