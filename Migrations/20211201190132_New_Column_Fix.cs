using Microsoft.EntityFrameworkCore.Migrations;

namespace MsBase.Migrations
{
    public partial class New_Column_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "Country",
               table: "MsBaseModel",
               type: "nvarchar(max)",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "MsBaseModel");
        }
    }
}
