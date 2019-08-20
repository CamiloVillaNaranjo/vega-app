using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature 1')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature 2')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature 3')");
            migrationBuilder.Sql("INSERT INTO Features(Name) VALUES('Feature 4')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Features WHERE Name IN('Feature 1','Feature 2','Feature 3','Feature 4')");
        }
    }
}
