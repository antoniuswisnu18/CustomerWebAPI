using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerWebAPI.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(225)", maxLength: 225, nullable: false),
                    customerAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customerId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
