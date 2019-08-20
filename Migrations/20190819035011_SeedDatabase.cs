using Microsoft.EntityFrameworkCore.Migrations;

namespace vega.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Insert Makes
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make 1')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make 2')");
            migrationBuilder.Sql("INSERT INTO Makes (Name) VALUES('Make 3')");

            //Insert Models
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model A - Make 1', (SELECT Id FROM Makes WHERE Name='Make 1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model B - Make 1', (SELECT Id FROM Makes WHERE Name='Make 1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model C - Make 1', (SELECT Id FROM Makes WHERE Name='Make 1'))");

            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model A - Make 2', (SELECT Id FROM Makes WHERE Name='Make 2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model B - Make 2', (SELECT Id FROM Makes WHERE Name='Make 2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model C - Make 2', (SELECT Id FROM Makes WHERE Name='Make 2'))");

            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model A - Make 3', (SELECT Id FROM Makes WHERE Name='Make 3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model B - Make 3', (SELECT Id FROM Makes WHERE Name='Make 3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name,MakeId) VALUES('Model C - Make 3', (SELECT Id FROM Makes WHERE Name='Make 3'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Makes WHERE Name IN ('Make 1','Make 2','Make 3')");
        }
    }
}
