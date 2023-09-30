using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurityPlus.Database.Migrations
{
    /// <inheritdoc />
    public partial class addedBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
        table: "Brands",
        columns: new[] { "BrandId", "Name", "Description", "LogoUrl", "CreatedAt", "UpdatedAt" },
        values: new object[,]
        {
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"), "GlamourGlow Cosmetics", "Elevate your beauty with GlamourGlow Cosmetics. We offer a stunning range of makeup and skincare products to enhance your natural radiance.", "logo1.jpg", DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"), "LuxeBeauty Essentials", "Discover luxury in every detail with LuxeBeauty Essentials. Our premium cosmetic products are designed to make you feel exquisite and confident.", "logo2.jpg", DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"), "NaturiGlow Organics", "NaturiGlow Organics brings you the power of nature in every skincare solution. Experience the beauty of organic ingredients with us.", "logo3.jpg", DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa9"), "EcoChic Cosmetix", "EcoChic Cosmetix is your eco-friendly beauty companion. We create sustainable and chic cosmetics that enhance your charm while caring for the planet.", "logo4.jpg", DateTime.UtcNow, DateTime.UtcNow },
            { new Guid("3fa85f64-5717-4562-b3fc-2c963f66afaa"), "RadianceRevive Skincare", "Revive your radiance with RadianceRevive Skincare. Our skincare products are formulated to illuminate your skin's natural glow.", "logo5.jpg", DateTime.UtcNow, DateTime.UtcNow },
        });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
