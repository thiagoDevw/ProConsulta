using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProConsulta.Migrations
{
    /// <inheritdoc />
    public partial class Initialapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a9f2fb8-20dc-4693-84f4-cef56e140230", "AQAAAAIAAYagAAAAEHcONQBypsPLYn/1aCkk9sixpWm07H1AvVQ3/Q9t+JWlD1DXsQAf0dwZf6f1lAmVTQ==", "038e5bc2-74d9-42ee-88f1-b8fe85a7f7fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95433ac4-2fe9-468f-b80d-b05ec3724d1d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a340c5c6-861e-499b-8a73-be91b850cb30", "AQAAAAIAAYagAAAAEOyy37kxVPDVymaINt0v61NyQ9dMdmjpN0Rky54xhfM69XKlSJKO2vkoW/4UMqV4rg==", "9e7377db-88bc-4272-b16a-b690fd219a53" });
        }
    }
}
