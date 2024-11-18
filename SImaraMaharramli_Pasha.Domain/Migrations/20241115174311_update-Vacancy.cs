﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SImaraMaharramli_Pasha.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateVacancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Vacancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Vacancies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Vacancies");
        }
    }
}
