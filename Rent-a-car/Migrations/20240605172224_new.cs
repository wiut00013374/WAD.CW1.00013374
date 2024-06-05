using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rent_a_car.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_users_UserId",
                table: "cars");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_users_UserId",
                table: "cars",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cars_users_UserId",
                table: "cars");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "cars",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_cars_users_UserId",
                table: "cars",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId");
        }
    }
}
