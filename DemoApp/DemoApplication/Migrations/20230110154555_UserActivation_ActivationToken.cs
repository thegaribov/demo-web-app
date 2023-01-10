using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApplication.Migrations
{
    public partial class UserActivation_ActivationToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ActivationToken",
                table: "UserActivations",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivationToken",
                table: "UserActivations");
        }
    }
}
