using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crmbacktest.Migrations
{
    /// <inheritdoc />
    public partial class CustomerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
