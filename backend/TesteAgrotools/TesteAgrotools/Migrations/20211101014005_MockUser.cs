using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteAgrotools.Migrations
{
    public partial class MockUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO User (UserName, Password) VALUES
                ('joao', '123'),
                ('paulo', '123'),
                ('ana', '123');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
