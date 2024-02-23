using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    public partial class Inttial_Migration_2024_23_02_002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userPhone",
                table: "Users",
                newName: "UserPhone");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "userEmail",
                table: "Users",
                newName: "UserEmail");

            migrationBuilder.RenameColumn(
                name: "profile",
                table: "Users",
                newName: "Profile");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Profile",
                table: "Users",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPhone",
                table: "Users",
                newName: "userPhone");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "Users",
                newName: "userEmail");

            migrationBuilder.RenameColumn(
                name: "Profile",
                table: "Users",
                newName: "profile");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "profile",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
