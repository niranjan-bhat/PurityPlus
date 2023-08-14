using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurityPlus.Database.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("AspNetRoles", new[] { "Id", "Name", "NormalizedName" },
                 values: new object[,]
        {
            { "8c5f33a8-afaf-4105-b10a-65615b8bcf9c", "manager", "MANAGER" },
            { "8c5f33a8-afaf-4105-b10a-65615b8bcf9a", "vendor", "VENDOR" },
            { "8c5f33a8-afaf-4105-b10a-65615b8bcf9b", "customer", "CUSTOMER" },
            { "8c5f33a8-afaf-4105-b10a-65615b8bcf95", "admin", "ADMIN" }
        });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
