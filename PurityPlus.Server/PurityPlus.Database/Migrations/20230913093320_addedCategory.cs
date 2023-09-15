using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurityPlus.Database.Migrations
{
    /// <inheritdoc />
    public partial class addedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "Categories",
        columns: new[] { "CategoryId", "Name", "Description", "ParentCategoryId", "CreatedAt", "UpdatedAt" },
        values: new object[,]
        {
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "Makeup", "A wide range of makeup products to enhance your beauty.", null, DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), "Skincare", "Products for maintaining healthy and glowing skin.", null, DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), "Hair Care", "Hair care essentials for beautiful and shiny hair.", null, DateTime.UtcNow, DateTime.UtcNow },
        });

            migrationBuilder.InsertData(
       table: "Categories",
       columns: new[] { "CategoryId", "Name", "Description", "ParentCategoryId", "CreatedAt", "UpdatedAt" },
       values: new object[,]
       {
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9"), "Lipstick", "A variety of lipstick shades to express your style.", new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afaa"), "Face", "Face makeup products for a flawless look.", new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), DateTime.UtcNow, DateTime.UtcNow },
       });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
