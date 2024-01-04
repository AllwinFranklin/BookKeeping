using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookKeeping.API.Migrations
{
    /// <inheritdoc />
    public partial class GetAllBooksSortByAurthorTitleSP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = "CREATE PROCEDURE [dbo].[GetAllBooksSortByAurthorTitleSP]\r\nAS\r\n\tSELECT Id, Publisher, AuthorLastName, AuthorFirstName, Title, Price\r\n\tFROM Books\r\n\tORDER BY AuthorLastName, AuthorFirstName, Title\r\nRETURN 0\r\n";
            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = "DROP PROCEDURE [dbo].[GetAllBooksSortByAurthorTitleSP]";
            migrationBuilder.Sql(procedure);
        }
    }
}
