using Microsoft.EntityFrameworkCore.Migrations;

namespace UserMangementWithIdentity.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [Identity].[Users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],[TwoFactorEnabled]) VALUES (N'e0d9d5c9-72d6-415d-bf2e-20d5aa84636d', N'Admin', N'Admin', N'admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAEAACcQAAAAEFtU+fua5dkKyiFTVJw49dcu5/zpdgpiSaBF5l4GPBtTwcWp8+sS0TVGFBWxT/dr+Q==', N'EBWJJHWQVS47AFLYX7HIVFIK6RQATETI', N'c7515438-863a-4b25-8aac-9e02020680e4', NULL, 0, NULL, 1, 0)");
            //("INSERT INTO [Identity].[Users] ([Id], [FirstName], [LastName], [ProfilePicture], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],[TwoFactorEnabled]) VALUES (N'348aa185-3798-4bea-9b0a-58e2bfabdbf6', N'Admin', N'Admin', N'admin', N'ADMIN', N'admin@admin.com', N'ADMIN@ADMIN.COM', N'AQAAAAEAACcQAAAAECzONyeD/ULuZoaiqp3pCnRkwNEWphzHo9F+KlEjJ3jF1pIrmOBn9gsMBD5zGV5Ljw==', N'NMHMCAFQ4HR2KHKDPGEM2X3Y7M26XRTP', N'a5b8fefa-964d-46d7-a10f-f2dc2c0fd41e',0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM [Identity].[UserRoles] Where Id='348aa185-3798-4bea-9b0a-58e2bfabdbf6'");
        }
    }
}
