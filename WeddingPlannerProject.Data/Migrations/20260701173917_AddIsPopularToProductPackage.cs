using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingPlannerProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPopularToProductPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPopular",
                table: "ProductPackages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPopular",
                table: "ProductPackages");
        }
    }
}
