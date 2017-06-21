using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace visualstudio.Migrations
{
    public partial class AddCompanyCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyCode",
                table: "Email",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "Email");
        }
    }
}
