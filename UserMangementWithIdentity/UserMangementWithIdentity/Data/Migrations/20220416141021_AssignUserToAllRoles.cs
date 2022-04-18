using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMangementWithIdentity.Data.Migrations
{
    public partial class AssignUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Identity].[UserRoles] (UserId,RoleId) SELECT 'e0d9d5c9-72d6-415d-bf2e-20d5aa84636d',Id FROM [Identity].[Roles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELET FORM [Identity].[UserRoles] WHERE UserId='e0d9d5c9-72d6-415d-bf2e-20d5aa84636d'");
        }
    }
}
